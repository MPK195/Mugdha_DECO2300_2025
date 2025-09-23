using UnityEngine;
using UnityEngine.InputSystem;  // for InputAction
using UnityEngine.XR;           // XR basics

public class RaycastSelector : MonoBehaviour
{
    [Header("Ray Setup")]
    public Transform rayOrigin;                // drag RightHandAnchor here
    public LayerMask interactableLayer;        // set to "Interactable"

    [Header("Input")]
    public InputActionProperty selectAction;   // drag XR controller trigger here

    [Header("Ray Settings")]
    public float rayLength = 10f;              // how far the ray goes
    public LineRenderer lineRenderer;          // optional, if you want to see the ray

    [Header("Mannequin Settings")]
    public int outfitIndex = 0;                // default outfit index

    private void Update()
    {
        // Draw ray for debug visualization
        if (lineRenderer != null && rayOrigin != null)
        {
            lineRenderer.positionCount = 2; // ensure it has 2 points
            lineRenderer.SetPosition(0, rayOrigin.position);
            lineRenderer.SetPosition(1, rayOrigin.position + rayOrigin.forward * rayLength);
        }

        // Check if trigger pressed safely
        if (selectAction != null && selectAction.action != null && selectAction.action.WasPerformedThisFrame())
        {
            FireRay();
        }
    }

    private void FireRay()
    {
        if (rayOrigin == null) return;

        Ray ray = new Ray(rayOrigin.position, rayOrigin.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, rayLength, interactableLayer))
        {
            Debug.Log("Hit: " + hit.collider.name);

            // If mannequin has a swapper
            MannequinSwapper swapper = hit.collider.GetComponentInParent<MannequinSwapper>();
            if (swapper != null)
            {
                swapper.SwapOutfit(outfitIndex);
                return;
            }

            // If BuyButton present
            BuyButton buyButton = hit.collider.GetComponent<BuyButton>();
            if (buyButton != null)
            {
                buyButton.OnBuyPressed();
                return;
            }
        }
        else
        {
            Debug.Log("Raycast did not hit any interactable.");
        }
    }
}
