using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public GameScenes Scenes;

    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnStartGame);
        }
        else
        {
            Debug.LogError("Check where you attached StartButton script. There is no button component here...");
        }
    }

    public void OnStartGame()
    {
        switch (Scenes)
        {
            case GameScenes.Gameplay:
                SceneManager.Instance.UpdateGameState(SceneState.Gameplay);
                break;
            case GameScenes.Tutorial:
                SceneManager.Instance.UpdateGameState(SceneState.Tutorial);
                break;
            case GameScenes.LevelSelect:
                SceneManager.Instance.UpdateGameState(SceneState.LevelSelect);
                break;
            case GameScenes.Gameplay1:
                SceneManager.Instance.UpdateGameState(SceneState.Gameplay1);
                break;
            case GameScenes.Gameplay2:
                SceneManager.Instance.UpdateGameState(SceneState.Gameplay2);
                break;
        }

    }
}
public enum GameScenes
{
    Gameplay,
    Tutorial,
    LevelSelect,
    Gameplay1, Gameplay2
}
