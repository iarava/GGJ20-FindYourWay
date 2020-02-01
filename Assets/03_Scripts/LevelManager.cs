using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    
    public event Action NewLevelReady = delegate { };
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void LoadLevel(int level)
    {
        NewLevelReady();
        SceneManager.LoadScene(level + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
