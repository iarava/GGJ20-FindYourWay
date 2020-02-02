using UnityEngine;

public class Restart : MonoBehaviour
{
    public void OnRestart()
    {
        LevelManager.Instance.Restart();
    }
}
