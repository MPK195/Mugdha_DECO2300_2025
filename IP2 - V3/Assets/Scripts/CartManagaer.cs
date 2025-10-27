using UnityEngine;

public class ClothesTriggerActivator : MonoBehaviour
{
    [Header("Target to Activate")]
    [Tooltip("Assign the GameObject that should be activated when clothes enter.")]
    [SerializeField] private GameObject objectToActivate;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the incoming object has the tag "Clothes"
        if (other.CompareTag("Colorchangeable"))
        {
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
            else
            {
                Debug.LogWarning($"{name}: No object assigned to activate.");
            }
        }
    }
}
