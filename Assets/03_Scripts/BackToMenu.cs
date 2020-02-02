using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    public void OnMenu()
    {
        LevelManager.Instance.LoadStartMenu();
    }
}
