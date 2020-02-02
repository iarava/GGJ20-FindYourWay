using UnityEngine;

public class WinLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            LevelManager.Instance.LoadStartMenu();
    }
}
