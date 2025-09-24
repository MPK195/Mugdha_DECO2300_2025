using UnityEngine;

public class MannequinSwapper : MonoBehaviour
{
    [Header("Setup")]
    public Transform outfitAnchor;        // drag OutfitAnchor here
    public GameObject[] outfitPrefabs;    // drag your clothing prefabs

    private int index = -1;
    private GameObject current;

    public void SwapNext()
    {
        if (!outfitAnchor || outfitPrefabs == null || outfitPrefabs.Length == 0) return;

        if (current) Destroy(current);
        index = (index + 1) % outfitPrefabs.Length;

        current = Instantiate(outfitPrefabs[index], outfitAnchor, false);
        current.transform.localPosition = Vector3.zero;
        current.transform.localRotation = Quaternion.identity;
        current.transform.localScale    = Vector3.one;

        Debug.Log($"[XR] Outfit → {current.name}");
    }

    public void SwapTo(int i)
    {
        if (!outfitAnchor || outfitPrefabs == null || outfitPrefabs.Length == 0) return;

        if (current) Destroy(current);
        index = Mathf.Clamp(i, 0, outfitPrefabs.Length - 1);

        current = Instantiate(outfitPrefabs[index], outfitAnchor, false);
        current.transform.localPosition = Vector3.zero;
        current.transform.localRotation = Quaternion.identity;
        current.transform.localScale    = Vector3.one;
    }

    // --- Wrappers to satisfy any older calls (e.g., from RaycastSelector.cs) ---
    public void SwapOutfit()      { SwapNext(); }
    public void SwapOutfit(int i) { SwapTo(i);  }
}
