using UnityEngine;

public class MannequinSlotAttach : MonoBehaviour
{
    [Header("Slots on the mannequin")]
    public Transform shirtSlot;          // drag ShirtSlot (child of spine_02.x)
    public Transform pantsSlot;          // drag PantsSlot (child of root.x / hips)

    [Header("Hand reference")]
    public Transform rightHandPalm;      // drag RightHandPalm (child of right hand/anchor)

    [Header("Detection")]
    public float holdScanRadius = 0.15f; // search radius around palm to find held item

    private void Start()
    {
        var gm = FindObjectOfType<GestureManager>();
        if (gm != null)
        {
            gm.OnPush += TryAttach;
        }
        else
        {
            Debug.LogWarning("[MannequinSlotAttach] No GestureManager found in scene.");
        }
    }

    private void TryAttach()
    {
        if (rightHandPalm == null) return;

        // look for a held clothing item near the palm
        Collider[] hits = Physics.OverlapSphere(rightHandPalm.position, holdScanRadius);
        foreach (var h in hits)
        {
            var item = h.GetComponentInParent<ItemGrabbable>();
            if (item != null && item.IsHeld)
            {
                switch (item.Type)
                {
                    case ItemGrabbable.ClothingType.Shirt:
                        if (shirtSlot != null)
                        {
                            item.SnapTo(shirtSlot);
                            Toast.Show("Shirt equipped!");
                        }
                        return;

                    case ItemGrabbable.ClothingType.Pants:
                        if (pantsSlot != null)
                        {
                            item.SnapTo(pantsSlot);
                            Toast.Show("Pants equipped!");
                        }
                        return;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (rightHandPalm == null) return;
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(rightHandPalm.position, holdScanRadius);
    }
}
