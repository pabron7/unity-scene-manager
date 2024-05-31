using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    public GameObject pauseMenu;
    [SerializeField]
    public GameObject consoleMenu;

    private bool isConsoleOn;
    private bool isPauseOn;


    void Update()
    {
        CheckMenuCall();
    }

    public void CheckMenuCall()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPauseOn) { isPauseOn = true; }
            else { isPauseOn = false; }
        }

        if (Input.GetButtonDown("Console"))
        {

            if (!isConsoleOn) { isConsoleOn = true; }
            else { isConsoleOn = false; }
        }
        UpdateMenu();
    }

    private void UpdateMenu()
    {
        if (isPauseOn) { pauseMenu.SetActive(true); }
        else { pauseMenu.SetActive(false); }

        if(isConsoleOn) { consoleMenu.SetActive(true); }
        else { consoleMenu.SetActive(false); }
    }
}

