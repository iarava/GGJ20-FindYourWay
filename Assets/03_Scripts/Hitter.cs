using System;
using UnityEngine;

public class Hitter : MonoBehaviour
{
    [SerializeField] private int powerOfHit = 1;

    private bool overDestroyableObject = false;
    private GameObject destroyableObject = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered");

        if (IsDestroyable(other))
        {
            overDestroyableObject = true;
            destroyableObject = other.gameObject;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger entered");

        if (IsDestroyable(other))
            overDestroyableObject = false;
            
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) & overDestroyableObject)
        {
            HitObject();
        }
    }

    private bool IsDestroyable(Collider2D other)
    {
        return other.CompareTag("Destroyable");
    }

    private void HitObject()
    {
        var script = destroyableObject.GetComponentInParent<Destroyable>();
        script.ApplyHit(powerOfHit);
        
        if(gameObject.CompareTag("Axe"))
            GameManager.Instance.UpdateAmountAxe();
        else
            GameManager.Instance.UpdateAmountPick();

        Destroy(gameObject);

        Cursor.visible = true;
    }
}
