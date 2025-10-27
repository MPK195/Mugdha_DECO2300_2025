using System;
using UnityEngine;

public class GestureManager : MonoBehaviour
{
    // Minimal event so MannequinSlotAttach can subscribe.
    public event Action OnPush;

    // Call this method from anywhere (or a button) to simulate a Push gesture.
    // Later, your real hand-tracking code will invoke OnPush for you.
    [ContextMenu("Simulate Push")]
    public void SimulatePush()
    {
        Debug.Log("[GestureManager] Simulate Push fired");
        OnPush?.Invoke();
    }
}
