using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance;
    public static MusicManager Instance     //to access globally
    {
        get
        {
            if (_instance == null)
            {
                GameObject newManager = new GameObject("MusicManager");
                _instance = newManager.AddComponent<MusicManager>();
                DontDestroyOnLoad(newManager);
            }
            return _instance;
        }
    }

    public AudioSource audioSource;

    public List<AudioClip> startMenuPlaylist;
    public List<AudioClip> gameplayPlaylist;
    public List<AudioClip> endScenePlaylist;

    private List<AudioClip> currentPlaylist;
    private int currentTrackIndex = 0;
    private bool isPlaying = false;

    void Awake()
    {
        SingletonCheck();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.loop = false;
            audioSource.playOnAwake = false;
        }
    }

    void Start()
    {
        SelectPlaylist("StartMenu");
    }

    /// <summary>
    /// Switches the currently playing playlist according to the given parameter. Please check the hardcoded values for this.
    /// </summary>
    /// <param name="playlistName"></param>
    public void SelectPlaylist(string playlistName)
    {
        switch (playlistName)
        {
            case "StartMenu":
                currentPlaylist = startMenuPlaylist;
                break;
            case "Gameplay":
                currentPlaylist = gameplayPlaylist;
                break;
            case "EndScene":
                currentPlaylist = endScenePlaylist;
                break;
            default:
                Debug.LogError("Playlist not found: " + playlistName);
                return;
        }
        currentTrackIndex = 0;
        PlayNextTrack();
    }

    private void PlayNextTrack()
    {
        if (currentPlaylist != null && currentPlaylist.Count > 0)
        {
            audioSource.clip = currentPlaylist[currentTrackIndex];
            audioSource.Play();
            isPlaying = true;
            currentTrackIndex = (currentTrackIndex + 1) % currentPlaylist.Count;
            StartCoroutine(WaitForTrackToEnd());
        }
    }

    private IEnumerator WaitForTrackToEnd()
    {
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        if (isPlaying)
        {
            PlayNextTrack();
        }
    }

    /// <summary>
    /// Plays the music at the current index of the selected playlist.
    /// </summary>
    public void Play()
    {
        if (!isPlaying)
        {
            isPlaying = true;
            if (!audioSource.isPlaying)
            {
                PlayNextTrack();
            }
            else
            {
                audioSource.Play();
            }
        }
    }

    /// <summary>
    /// Pause currently playing music.
    /// </summary>
    public void Pause()
    {
        if (isPlaying)
        {
            isPlaying = false;
            audioSource.Pause();
        }
    }

    /// <summary>
    /// Plays the next index of the current playlist.
    /// </summary>
    public void NextSong()
    {
        if (currentPlaylist != null && currentPlaylist.Count > 0)
        {
            audioSource.Stop();
            PlayNextTrack();
        }
    }

    /// <summary>
    /// Set the volume from 0 to 1.
    /// </summary>
    /// <param name="volume"></param>
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    /// <summary>
    /// Plays the song at the given index in the current playlist.
    /// </summary>
    /// <param name="index"></param>
    public void PlaySongAtIndex(int index)
    {
        if (currentPlaylist != null && index >= 0 && index < currentPlaylist.Count)
        {
            currentTrackIndex = index;
            audioSource.clip = currentPlaylist[currentTrackIndex];
            audioSource.Play();
            isPlaying = true;
            currentTrackIndex = (currentTrackIndex + 1) % currentPlaylist.Count;
            StopAllCoroutines();
            StartCoroutine(WaitForTrackToEnd());
        }
        else
        {
            Debug.LogError("Invalid index or playlist is empty.");
        }
    }

    /// <summary>
    /// Singleton pattern checker method.
    /// </summary>
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
