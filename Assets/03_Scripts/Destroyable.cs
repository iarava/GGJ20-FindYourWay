using System;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    [SerializeField] private int hitsToDestroy = 1;

    private int remainingHits;

    private void Awake()
    {
        remainingHits = hitsToDestroy;
    }

    public void ApplyHit(int amount)
    {
        remainingHits -= amount;
        if (remainingHits <= 0)
            Destroy(gameObject);
    }
}
