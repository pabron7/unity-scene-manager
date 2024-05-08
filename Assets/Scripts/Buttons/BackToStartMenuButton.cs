using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackToStartMenu : MonoBehaviour
{
    
    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(BackToStart);
        }
        else
        {
            Debug.LogError("Check where you attached StartButton script. There is no button component here...");
        }
    }

    public void BackToStart()
    {
        SceneManager.Instance.UpdateGameState(SceneState.StartMenu);
    }
}
