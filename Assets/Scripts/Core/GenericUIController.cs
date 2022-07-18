using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenericUIController : MonoBehaviour
{
    /**
     * Create an audio source to use for button effects.
     */
    public AudioSource menuAudio;

    /**
     * Called when the scene starts.
     */
    public void Start()
    {
        menuAudio = gameObject.AddComponent<AudioSource>();
    }

    /**
     * Play a simple UI sound.
     */
    public void PlaySimpleSound(AudioClip sound)
    {
        menuAudio.clip = sound;
        menuAudio.Play();
    }

    /**
     * Open a scene from the menu with the given scene name.
     */
    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
