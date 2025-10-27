using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Collider))]
public class ApplyMaterialOnContact : MonoBehaviour
{
    [Header("Drag your material here from the Assets folder")]
    public Material materialA;

    [Tooltip("Also change materials on all child renderers of the hit object.")]
    public bool includeChildren = true;

    private void Reset()
    {
        // Make sure the collider is a trigger
        var col = GetComponent<Collider>();
        col.isTrigger = true;

        // Ensure a Rigidbody exists so OnTriggerEnter fires
        if (!TryGetComponent<Rigidbody>(out var rb))
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.useGravity = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (materialA == null) return;
        if (!other.CompareTag("Colorchangeable")) return;

        if (includeChildren)
        {
            foreach (var r in other.GetComponentsInChildren<Renderer>(true))
                ApplyToRenderer(r, materialA);
        }
        else
        {
            var r = other.GetComponent<Renderer>();
            if (r != null) ApplyToRenderer(r, materialA);
        }
    }

    private static void ApplyToRenderer(Renderer r, Material mat)
    {
        if (r == null || mat == null) return;

        // Replace all submesh slots with Material A
        var mats = r.sharedMaterials;            // avoids creating per-renderer material instances
        for (int i = 0; i < mats.Length; i++)
            mats[i] = mat;
        r.sharedMaterials = mats;
    }
}
