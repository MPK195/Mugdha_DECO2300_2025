using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CartManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text cartText;          // shows number of items in cart
    public GameObject checkoutPanel;   // panel that opens on checkout
    public TMP_Text checkoutList;      // list of items in checkout

    private List<string> cartItems = new List<string>();

    public void AddToCart(string itemName)
    {
        cartItems.Add(itemName);
        UpdateCartUI();
    }

    public void Checkout()
    {
        if (checkoutPanel == null) return;

        checkoutPanel.SetActive(true);
        checkoutList.text = "Your Cart:\n";
        foreach (var item in cartItems)
        {
            checkoutList.text += "- " + item + "\n";
        }
    }

    public void CloseCheckout()
    {
        if (checkoutPanel != null)
            checkoutPanel.SetActive(false);
    }

    private void UpdateCartUI()
    {
        if (cartText != null)
            cartText.text = "Cart: " + cartItems.Count;
    }
}
