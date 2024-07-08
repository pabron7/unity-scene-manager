using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    public float hoverScaleFactor = 1.1f; 
    public AudioClip hoverSound; 
    private AudioSource audioSource;

    void Start()
    {
        originalScale = transform.localScale;

        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on " + gameObject.name);
        }
    }

    /// <summary>
    /// Method called when the pointer enters the button. Scales the button up by the hover scale factor
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = originalScale * hoverScaleFactor;
        Debug.Log("Pointer entered " + gameObject.name + ", scaling up.");

        SoundManager.Instance.PlayOneShotSound("Button");
    }

    // 
    /// <summary>
    /// Method called when the pointer exits the button. Reverts the button back to its original scale.
    /// </summary>
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale;
        Debug.Log("Pointer exited " + gameObject.name + ", scaling down.");
    }
}
