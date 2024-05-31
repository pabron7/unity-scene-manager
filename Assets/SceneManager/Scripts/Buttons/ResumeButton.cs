using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{


    public GameObject pauseMenu;

    void Awake()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ResumeGame);
        }
        else
        {
            Debug.LogError("Check where you attached ResumeButton script. There is no button component here...");
        }
    }

    private void ResumeGame()
    {
        pauseMenu.SetActive(false);
    }
}
