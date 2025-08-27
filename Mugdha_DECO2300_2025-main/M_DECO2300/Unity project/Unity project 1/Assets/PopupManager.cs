using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public GameObject jacketPopup;
    public GameObject teePopup;
    public GameObject jeansPopup;

    public void ShowJacketPopup()
    {
        CloseAll();
        jacketPopup.SetActive(true);
    }

    public void ShowTeePopup()
    {
        CloseAll();
        teePopup.SetActive(true);
    }

    public void ShowJeansPopup()
    {
        CloseAll();
        jeansPopup.SetActive(true);
    }

    public void CloseAll()
    {
        jacketPopup.SetActive(false);
        teePopup.SetActive(false);
        jeansPopup.SetActive(false);
    }
}
