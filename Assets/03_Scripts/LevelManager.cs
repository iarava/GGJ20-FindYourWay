using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    
    public event Action<int, int, int, int> NewLevelReady = delegate { };

    public ItemsPerLevel[] ItemsPerLevels;

    private int actualLevel = 0;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel(int level)
    {
        actualLevel = level;
        var axes = ItemsPerLevels[level].countAxes; 
        var picks = ItemsPerLevels[level].countPicks; 
        var ramps = ItemsPerLevels[level].countRamps; 
        var bridges = ItemsPerLevels[level].countBridges; 
        NewLevelReady(axes,picks,ramps,bridges);
        SceneManager.LoadScene(level + 1);
    }

    public void Restart()
    {
        LoadLevel(actualLevel);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
