using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public GameObject pauseMenu;

    void Start()
    {
        
    }

    void Update()
    {
        CheckMenuCall();
    }

    public void CheckMenuCall()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            pauseMenu.SetActive(true);
        }
    }
}
