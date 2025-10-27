using UnityEngine;

// Minimal "toast" that just logs to Console.
// You can upgrade later to show TextMeshPro on a world-space canvas.
public class Toast : MonoBehaviour
{
    public static void Show(string msg)
    {
        Debug.Log("[Toast] " + msg);
    }
}
