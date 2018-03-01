using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHealthPopup : MonoBehaviour {

    public GameObject Panel;
    public GameObject HealthNoPickup;
    public GameObject HealthButton;
    public GameObject DissapearPopup;

    void ClosePopup()
    {
        Panel.gameObject.SetActive(false);
        HealthNoPickup.gameObject.SetActive(false);
        HealthButton.gameObject.SetActive(false);
        DissapearPopup.gameObject.SetActive(false);
    }
}
