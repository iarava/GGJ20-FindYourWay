using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuController : MonoBehaviour
{
    public void OnLoadLevel(int level)
    {
        LevelManager.Instance.LoadLevel(level-1);
    }

    public void OnQuitGame()
    {
        LevelManager.Instance.QuitGame();
    }
}
