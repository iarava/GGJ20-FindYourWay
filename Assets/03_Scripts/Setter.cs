using System;
using UnityEngine;

public class Setter : MonoBehaviour
{
    private bool isSnapPossible = false;
    private GameObject snapObject = null;

    private BoxCollider2D collider2D;
    private TrackMousPosition trackMousePos;

    private void Start()
    {
        trackMousePos = gameObject.GetComponent<TrackMousPosition>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered");

        if (IsDestroyable(other))
        {
            isSnapPossible = true;
            snapObject = other.gameObject;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger entered");

        if (IsDestroyable(other))
            isSnapPossible = false;
            
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) & isSnapPossible)
        {
            SnapObject();
        }
    }

    private bool IsDestroyable(Collider2D other)
    {
        return other.CompareTag("Snapable");
    }

    private void SnapObject()
    {
        transform.position = snapObject.transform.position;

        trackMousePos.enabled = false;

        if(gameObject.CompareTag("Ramp"))
            GameManager.Instance.UpdateAmountRamp();
        else
            GameManager.Instance.UpdateAmountBrdige();

        Cursor.visible = true;
        isSnapPossible = false;
    }
}
