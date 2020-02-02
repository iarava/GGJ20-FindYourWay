using System;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    [SerializeField] private int hitsToDestroy = 1;
    [SerializeField] private AudioManager.SoundType soundEffect;

    private int remainingHits;

    private void Awake()
    {
        remainingHits = hitsToDestroy;
    }

    public void ApplyHit(int amount)
    {
        AudioManager.Instance.Play(soundEffect);
        remainingHits -= amount;
        if (remainingHits <= 0)
            Destroy(gameObject);
    }
}
