using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager
{
    public int maxLevelId = 3;

    public int levelId
    {
        get { return PlayerPrefs.GetInt(Prefs.LEVEL_ID, 1); }
        set
        {
            int newValue = Mathf.Clamp(value, 1, maxLevelId);
            PlayerPrefs.SetInt(Prefs.LEVEL_ID, newValue);
        }
    }

    public LevelLoaderBase levelLoader;

    public void LoadLevel()
    {
        levelLoader.LoadLevel(levelId);
    }
}
