using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{

    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(QuitGame);
        }
        else
        {
            Debug.LogError("Check where you attached StartButton script. There is no button component here...");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit function is called");
    }
}