using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    public int gameWidth = 8;
    public int gameHeight = 8;

    public List<Sprite> levelSprites;
    public List<int> scoreStructure = new List<int>() { 0, 0, 0, 100, 150, 225, 300 };
}
