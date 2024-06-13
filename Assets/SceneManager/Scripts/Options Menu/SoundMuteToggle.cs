using UnityEngine;
using UnityEngine.UI;

public class SoundMuteToggle : MonoBehaviour
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
