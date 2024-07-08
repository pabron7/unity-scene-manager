using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeSlider : MonoBehaviour
{
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public Slider GetSlider()
    {
        return slider;
    }
}
