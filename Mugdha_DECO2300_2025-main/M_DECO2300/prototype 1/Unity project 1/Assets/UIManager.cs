using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text selectedText;

    public void SelectItem(string itemName)
    {
        if (selectedText != null)
            selectedText.text = "Selected: " + itemName;
    }
}