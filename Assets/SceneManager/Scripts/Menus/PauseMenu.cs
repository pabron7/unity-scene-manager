using UnityEngine;

public class PauseMenu : MonoBehaviour
{
 
    void OnEnable()
    {
        PauseGame();
    }

    private void OnDisable()
    {
        ResumeGame();
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        Debug.Log("Pause menu is enabled and time scale is set to 0");
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        Debug.Log("Pause menu is disable and time scale is set to 1");
    }

}
