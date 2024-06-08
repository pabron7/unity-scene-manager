using System.Collections;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private static SceneManager _instance;
    public static SceneManager Instance     //to access globally
    {
        get
        {
            if (_instance == null)
            {
                GameObject newManager = new GameObject("SceneManager");
                _instance = newManager.AddComponent<SceneManager>();
                DontDestroyOnLoad(newManager);
            }
            return _instance;
        }
    }

    public SceneState currentState;

    void Awake()
    {
        SingletonCheck();
    }

    void Start()
    {
        UpdateGameState(SceneState.StartMenu);
    }

    /// <summary>
    /// To change between scenes, simply call one as a parameter. Pick one of the following; "StartMenu", "Gameplay", "EndScene".
    /// </summary>
    public void UpdateGameState(SceneState newState)
    {
        currentState = newState;
        switch (currentState)
        {
            case SceneState.StartMenu:
                LoadScene("StartMenu");
                MusicManager.Instance.SelectPlaylist("StartMenu");
                UnlockCursor();
                break;
            case SceneState.Gameplay:
                LoadScene("Gameplay");
                MusicManager.Instance.SelectPlaylist("Gameplay");
                SoundManager.Instance.PlayOneShotSound("mrSandmanNarrative");
                break;
            case SceneState.EndScene:
                LoadScene("EndScene");
                MusicManager.Instance.SelectPlaylist("EndScene");
                UnlockCursor();
                break;
        }
    }

    /// <summary>
    /// This function loads scenes. Simply provide a scene as a parameter.
    /// </summary>
    void LoadScene(string sceneName)
    {
        try
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Failed to load scene: " + ex.Message);
        }
    }

    /// <summary>
    /// This function loads the scene asynchronously. Could be useful to display some loading screen.
    /// </summary>
    /// <returns></returns>
    public IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            // Set loading Screen UI On

            yield return null;
        }
    }

    /// <summary>
    /// Checks if there is any other instances of this object and does the required.
    /// </summary>
    void SingletonCheck()
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

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}



/// <summary>
/// Scenes data, hard coded
/// </summary>
public enum SceneState
{
    StartMenu,
    Gameplay,
    EndScene
}
