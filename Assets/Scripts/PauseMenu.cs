using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
 
    void Start()
    {
        PauseGame();
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        Debug.Log("Pause menu is enabled and time scale is set to 0");
        //add pause function for audio listener too
    }

}
