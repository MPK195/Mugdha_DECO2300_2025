using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemGrabbable : MonoBehaviour
{
    public enum ClothingType { Shirt, Pants }

    [Header("Type of clothing")]
    public ClothingType Type = ClothingType.Shirt;

    // Set true while the item is being held (your pickup code should toggle this).
    public bool IsHeld { get; private set; }

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        // Reasonable defaults for physics props if not set:
        rb.useGravity = true;
        rb.isKinematic = false;
    }

    // Call when you pick up the item (attach to hand).
    public void AttachTo(Transform hand)
    {
        IsHeld = true;
        rb.isKinematic = true;
        transform.SetParent(hand);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    // Call when you snap onto a mannequin slot.
    public void SnapTo(Transform slot)
    {
        IsHeld = false;
        rb.isKinematic = true;
        transform.SetParent(slot);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        // Optional: if you later add a ClothingFitOffset, apply it here.
        var fit = GetComponent<ClothingFitOffset>();
        if (fit)
        {
            transform.localPosition += fit.localPositionOffset;
            transform.localRotation *= Quaternion.Euler(fit.localEulerOffset);
        }
    }

    // Call if you drop it back into the world.
    public void Detach()
    {
        IsHeld = false;
        transform.SetParent(null);
        rb.isKinematic = false;
    }
}
