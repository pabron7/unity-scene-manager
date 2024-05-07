using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
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
        SceneManager.Instance.UpdateGameState(SceneState.Gameplay);
    }
}
