using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public enum SoundType
    {
        GAME_SOUND,
        WOOD,
        ROCK,
        BUILD
    }

    public static AudioManager Instance { get; private set; }

    [SerializeField]
    private Sound[] sounds;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        
        foreach (Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();

            s.audioSource.playOnAwake = false;

            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.volume;
            s.audioSource.loop = s.loop;
            s.audioSource.mute = s.mute;
        }
    }

    private void Start()
    {
        Play(SoundType.GAME_SOUND);
    }

    public void Play(SoundType soundType)
    {
        Sound s = Array.Find(sounds, sound => sound.soundType == soundType);
        if(s == null)
        {
            Debug.LogWarning("Sound " + name + " not found");
            return;
        }
        s.audioSource.Play();
    }

    public void Stop(SoundType soundType)
    {
        Sound s = Array.Find(sounds, sound => sound.soundType == soundType);
        if (s == null)
        {
            Debug.LogWarning("Sound not found");
            return;
        }
        s.audioSource.Stop();
    }
}
