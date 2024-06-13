using UnityEngine;
using UnityEngine.UI;

public class MusicMuteToggle : MonoBehaviour
{
    private Toggle toggle;

    void Awake()
    {
        toggle = GetComponent<Toggle>();
    }

    public Toggle GetToggle()
    {
        return toggle;
    }
}
