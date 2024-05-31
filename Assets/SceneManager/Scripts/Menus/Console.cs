using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Console : MonoBehaviour
{
    [SerializeField]
    public TMP_InputField inputField;
    [SerializeField]
    public TextMeshProUGUI consoleText;

    private string entry;

    void Start()
    {
        inputField = inputField.GetComponent<TMP_InputField>();
        inputField.interactable = true;
    }

    void Update()
    {
        ReadEntry();
        ShowEntry();
        SetEntry();
    }

    private void ReadEntry()
    {
        entry = inputField.text;
   
        Debug.Log(entry);
    }

    private void ShowEntry()
    {
        consoleText.text = entry;
    }

    private void SetEntry()
    {
        if (Input.GetButtonDown("Enter") && inputField.text != null)
        {
            consoleText.text += entry;
        }
    }
}
