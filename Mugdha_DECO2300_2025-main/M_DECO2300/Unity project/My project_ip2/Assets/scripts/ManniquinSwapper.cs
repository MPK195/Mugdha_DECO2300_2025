using UnityEngine;

public class MannequinSwapper : MonoBehaviour
{
    [Header("Setup References")]
    public Transform outfitAnchor;             // Empty GameObject on mannequin where outfits attach
    public GameObject[] outfitPrefabs;         // Array of possible outfits
    public GameObject purchasePanelPrefab;     // Prefab for buy panel

    private GameObject currentOutfit;
    private GameObject purchasePanelInstance;

    // Example method to swap outfit
    public void SwapOutfit(int index)
    {
        if (index < 0 || index >= outfitPrefabs.Length) return;

        // Destroy old outfit
        if (currentOutfit != null)
            Destroy(currentOutfit);

        // Spawn new outfit under anchor
        currentOutfit = Instantiate(outfitPrefabs[index], outfitAnchor.position, outfitAnchor.rotation, outfitAnchor);

        // Show purchase panel if not already shown
        if (purchasePanelInstance == null && purchasePanelPrefab != null)
        {
            purchasePanelInstance = Instantiate(purchasePanelPrefab, transform.position + transform.forward * 1.5f, Quaternion.identity);
            purchasePanelInstance.SetActive(true);
        }
    }
}
