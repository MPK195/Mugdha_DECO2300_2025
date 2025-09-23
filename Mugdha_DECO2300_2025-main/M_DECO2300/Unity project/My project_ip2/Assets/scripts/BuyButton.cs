using System.Collections;
using UnityEngine;
using TMPro; // Needed if using TextMeshPro

public class BuyButton : MonoBehaviour
{
    public TMP_Text confirmationText; // Drag the ConfirmationText object here
    public float confirmationDuration = 2f; // How long the "Purchased!" text stays visible
    public AudioClip buySound; // Optional sound when buying

    private AudioSource sfx;

    void Awake()
    {
        // Make sure we have an AudioSource
        sfx = GetComponent<AudioSource>();
        if (sfx == null) sfx = gameObject.AddComponent<AudioSource>();

        // Hide the confirmation text initially
        if (confirmationText != null)
            confirmationText.gameObject.SetActive(false);
    }

    // Call this function when the buy button is clicked or triggered
    public void OnBuyPressed()

    {
        if (buySound != null)
            sfx.PlayOneShot(buySound);

        if (confirmationText != null)
        {
            StopAllCoroutines(); // Stop previous coroutine if still running
            confirmationText.gameObject.SetActive(true);
            StartCoroutine(HideAfter());
        }
    }

    IEnumerator HideAfter()
    {
        yield return new WaitForSeconds(confirmationDuration);
        if (confirmationText != null)
            confirmationText.gameObject.SetActive(false);
    }
}
