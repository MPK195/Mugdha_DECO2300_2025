using UnityEngine;

public class ThumbsUp : MonoBehaviour
{
    public OVRHand hand;

    void Update()
    {
        if (hand == null) return;

        // Example: detect thumbs up gesture
        if (IsThumbsUp())
        {
            Debug.Log("👍 Thumbs Up detected!");
        }
        else
        {
            // Optional: track when hand is not thumbs up
            Debug.Log("Hand not thumbs up");
        }
    }

    bool IsThumbsUp()
    {
        if (hand.HandConfidence != OVRHand.TrackingConfidence.High) return false;

        bool thumbPinch = hand.GetFingerIsPinching(OVRHand.HandFinger.Thumb);
        float idx = hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
        float mid = hand.GetFingerPinchStrength(OVRHand.HandFinger.Middle);
        float rng = hand.GetFingerPinchStrength(OVRHand.HandFinger.Ring);
        float pnk = hand.GetFingerPinchStrength(OVRHand.HandFinger.Pinky);

        // ✅ This is the actual condition
        return !thumbPinch && idx < 0.3f && mid < 0.3f && rng < 0.3f && pnk < 0.3f;
    }
}
