using UnityEngine;
using UnityEngine.UI;

public class SideMenuController : MonoBehaviour
{
    public GameObject sideMenu; 
    public GameObject creditsContent; 
    public GameObject controlsContent; 
    public GameObject optionsContent;
    public Button closeButton; 

    private enum Contents
    {
        Credits,
        Controls,
        Options
    }

    private void Start()
    {
        // Initially, hide the side menu and its content
        sideMenu.SetActive(false);
        creditsContent.SetActive(false);
        controlsContent.SetActive(false);
        if (optionsContent != null)
        {
            optionsContent.SetActive(false);
        }

        closeButton.onClick.AddListener(CloseSideMenu);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UpdateSideMenu(string name)
    {
        Contents content;
        if (System.Enum.TryParse(name, true, out content))
        {
            OpenSideMenu();
            switch (content)
            {
                case Contents.Credits:
                    creditsContent.SetActive(true);
                    controlsContent.SetActive(false);
                    if (optionsContent != null) optionsContent.SetActive(false);
                    break;
                case Contents.Controls:
                    creditsContent.SetActive(false);
                    controlsContent.SetActive(true);
                    if (optionsContent != null) optionsContent.SetActive(false);
                    break;
                case Contents.Options:
                    creditsContent.SetActive(false);
                    controlsContent.SetActive(false);
                    if (optionsContent != null) optionsContent.SetActive(true);
                    break;
            }
        }
        else
        {
            Debug.LogWarning("Invalid content name: " + name);
        }
    }

    private void OpenSideMenu()
    {
        if (!sideMenu.activeSelf)
        {
            sideMenu.SetActive(true);
        }
    }

    public void CloseSideMenu()
    {
        sideMenu.SetActive(false);
    }
}
