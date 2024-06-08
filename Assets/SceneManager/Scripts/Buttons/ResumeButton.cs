using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{
    public GameObject pauseMenu;
    public MenuController menuController;

    void Start()
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
        if (menuController != null)
        {
            menuController.ResumeGame();
        }
        else
        {
            Debug.LogError("MenuController not found on pauseMenu object.");
        }
    }
}
