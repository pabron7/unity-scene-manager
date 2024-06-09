using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    public float hoverScaleFactor = 1.1f; // Scale factor when hovering
    public AudioClip hoverSound; // Sound effect to play on hover
    private AudioSource audioSource;

    void Start()
    {
        // Store the original scale of the button
        originalScale = transform.localScale;

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Check if AudioSource component is found
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on " + gameObject.name);
        }
    }

    // Method called when the pointer enters the button
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Scale the button up by the hover scale factor
        transform.localScale = originalScale * hoverScaleFactor;
        Debug.Log("Pointer entered " + gameObject.name + ", scaling up.");

        // Play the hover sound effect
        if (audioSource != null && hoverSound != null)
        {
            audioSource.PlayOneShot(hoverSound);
        }
    }

    // Method called when the pointer exits the button
    public void OnPointerExit(PointerEventData eventData)
    {
        // Revert the button back to its original scale
        transform.localScale = originalScale;
        Debug.Log("Pointer exited " + gameObject.name + ", scaling down.");
    }
}
