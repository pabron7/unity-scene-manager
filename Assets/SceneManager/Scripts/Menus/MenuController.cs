using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject consoleMenu;

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
            isPauseOn = !isPauseOn;
        }

        if (Input.GetButtonDown("Console"))
        {
            isConsoleOn = !isConsoleOn;
        }

        UpdateMenu();
    }

    private void UpdateMenu()
    {
        if (isPauseOn || isConsoleOn)
        {
            pauseMenu.SetActive(isPauseOn);
            consoleMenu.SetActive(isConsoleOn);
            UnlockCursor();
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            consoleMenu.SetActive(false);
            LockCursor();
            Time.timeScale = 1f;
        }
    }

    public void ResumeGame()
    {
        isPauseOn = false;
        UpdateMenu();
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        LockCursor();
        Time.timeScale = 1f;
    }
}
