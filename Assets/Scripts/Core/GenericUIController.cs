using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenericUIController : MonoBehaviour
{
    // Create an audio source to use for button effects.
    public AudioSource menuAudio;

    // Called when the scene starts.
    public void Start()
    {
        menuAudio = gameObject.AddComponent<AudioSource>();
    }

    // Play a simple UI sound.
    public void PlaySimpleSound(AudioClip sound)
    {
        menuAudio.clip = sound;
        menuAudio.Play();
    }

    //Open a scene from the menu with the given scene name.
    public void OpenScene(string sceneName)
    {
        StartCoroutine(StartOpenRoutine(sceneName));
    }

    // Put our delay in for opening the scene for if there's any menu UI. Input sound should finish.
    IEnumerator StartOpenRoutine(string sceneName)
    {
        yield return new WaitWhile(() => menuAudio.isPlaying);
        SceneManager.LoadScene(sceneName);
    }
}
