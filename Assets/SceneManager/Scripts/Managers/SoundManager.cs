using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject newManager = new GameObject("SoundManager");
                _instance = newManager.AddComponent<SoundManager>();
                DontDestroyOnLoad(newManager);
            }
            return _instance;
        }
    }

    public AudioSource loopingSource;
    public List<AudioSource> oneShotSources;
    public List<AudioClip> soundEffects;

    private Dictionary<string, AudioClip> soundEffectDictionary = new Dictionary<string, AudioClip>();
    private int oneShotChannelCount = 5;  // Number of one-shot channels

    void Awake()
    {
        SingletonCheck();

        if (loopingSource == null)
        {
            loopingSource = gameObject.AddComponent<AudioSource>();
            loopingSource.loop = true;
            loopingSource.playOnAwake = false;
        }

        oneShotSources = new List<AudioSource>();
        for (int i = 0; i < oneShotChannelCount; i++)
        {
            AudioSource oneShotSource = gameObject.AddComponent<AudioSource>();
            oneShotSource.loop = false;
            oneShotSource.playOnAwake = false;
            oneShotSources.Add(oneShotSource);
        }

        // Initialize the sound effect dictionary
        foreach (var clip in soundEffects)
        {
            soundEffectDictionary[clip.name] = clip;
        }
    }

    /// <summary>
    /// Plays a looping sound effect by name.
    /// </summary>
    /// <param name="soundName">The name of the sound effect to play.</param>
    public void PlayLoopingSound(string soundName)
    {
        if (soundEffectDictionary.TryGetValue(soundName, out AudioClip clip))
        {
            if (loopingSource.isPlaying && loopingSource.clip == clip) return;  // Already playing this sound
            loopingSource.clip = clip;
            loopingSource.Play();
        }
        else
        {
            Debug.LogWarning("Looping sound not found: " + soundName);
        }
    }

    /// <summary>
    /// Stops the currently playing looping sound effect.
    /// </summary>
    public void StopLoopingSound()
    {
        loopingSource.Stop();
    }

    /// <summary>
    /// Plays a one-shot sound effect by name.
    /// </summary>
    /// <param name="soundName">The name of the sound effect to play.</param>
    public void PlayOneShotSound(string soundName)
    {
        if (soundEffectDictionary.TryGetValue(soundName, out AudioClip clip))
        {
            AudioSource availableSource = GetAvailableOneShotSource();
            if (availableSource != null)
            {
                availableSource.PlayOneShot(clip);
            }
            else
            {
                Debug.LogWarning("No available channels to play the one-shot sound: " + soundName);
            }
        }
        else
        {
            Debug.LogWarning("One-shot sound not found: " + soundName);
        }
    }

    /// <summary>
    /// Stops all currently playing one-shot sound effects.
    /// </summary>
    public void StopAllOneShotSounds()
    {
        foreach (var source in oneShotSources)
        {
            source.Stop();
        }
    }

    /// <summary>
    /// Sets the volume of the looping and one-shot sound effects.
    /// </summary>
    /// <param name="volume">The volume level to set (0.0 to 1.0).</param>
    public void SetVolume(float volume)
    {
        loopingSource.volume = volume;
        foreach (var source in oneShotSources)
        {
            source.volume = volume;
        }
    }

    /// <summary>
    /// Gets an available one-shot audio source.
    /// </summary>
    /// <returns>An available audio source, or null if all are in use.</returns>
    private AudioSource GetAvailableOneShotSource()
    {
        foreach (var source in oneShotSources)
        {
            if (!source.isPlaying)
            {
                return source;
            }
        }
        return null;  // All sources are currently in use
    }

    private void SingletonCheck()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
