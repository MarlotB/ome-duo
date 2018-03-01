using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRentPopup : MonoBehaviour {

    public GameObject Panel2;
    public GameObject RentNoPickup;
    public GameObject RentButton;
    public GameObject DissapearPopup;

    public void ClosePopup2()
    {
        Panel2.gameObject.SetActive(false);
        RentNoPickup.gameObject.SetActive(false);
        RentButton.gameObject.SetActive(false);
        DissapearPopup.gameObject.SetActive(false);
    }
}

