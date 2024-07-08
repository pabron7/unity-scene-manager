using System.Collections.Generic;
using UnityEngine;

public abstract class AudioManagerBase : MonoBehaviour
{
    public AudioSource audioSource;
    public float volume = 1.0f;

    protected virtual void Awake()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.loop = false;
            audioSource.playOnAwake = false;
        }
        SetVolume(volume);
    }

    public void SetVolume(float volume)
    {
        this.volume = volume;
        audioSource.volume = volume;
    }
}
