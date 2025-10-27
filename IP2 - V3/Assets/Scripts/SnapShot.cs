using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction; // for Grabbable (Meta SDK)

[RequireComponent(typeof(Collider))]
public class SnapSlotCartHook : MonoBehaviour
{
    [Tooltip("What we consider 'close enough' to treat as snapped (meters).")]
    public float snapProximity = 0.08f;

    public Transform currentSnapped { get; private set; }

    private readonly HashSet<Transform> _inside = new HashSet<Transform>();

    void OnTriggerEnter(Collider other)
    {
        var root = other.attachedRigidbody ? other.attachedRigidbody.transform : other.transform;
        _inside.Add(root);
    }

    void OnTriggerExit(Collider other)
    {
        var root = other.attachedRigidbody ? other.attachedRigidbody.transform : other.transform;
        _inside.Remove(root);
        if (currentSnapped == root) currentSnapped = null;
    }

    void Update()
    {
        // pick the nearest “released” clothing inside the trigger as snapped
        Transform best = null; float bestD = float.MaxValue;

        foreach (var t in _inside)
        {
            if (t == null) continue;

            // must have a Grabbable (your clothes do)
            var grab = t.GetComponentInParent<Grabbable>();
            if (grab != null && grab.SelectingPointsCount > 0) continue; // still held

            float d = Vector3.Distance(t.position, transform.position);
            if (d < bestD) { bestD = d; best = t; }
        }

        currentSnapped = (bestD <= snapProximity) ? best : null;
    }
}
