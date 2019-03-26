using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_Enable : MonoBehaviour
{
    public GameObject Focus;
    public GameObject WorldAR;
    public GameObject cameras;
    public GameObject events;
    public GameObject location;
    public GameObject panel;
    public GameObject acceptbutton;
    public GameObject relocate;


    public void Toggle_Changed(bool newValue)
    {
        if (cameras.activeSelf == true)
        {
            cameras.SetActive(false);
            events.SetActive(false);
            location.SetActive(false);
            panel.SetActive(false);
            acceptbutton.SetActive(false);
            relocate.SetActive(false);

            WorldAR.SetActive(true);
            Focus.SetActive(true);

            
            
        }
        else if (cameras.activeSelf == false)
        {
            cameras.SetActive(true);
            events.SetActive(true);
            location.SetActive(true);
            panel.SetActive(true);
            acceptbutton.SetActive(true);
            relocate.SetActive(true);

            WorldAR.SetActive(false);
            Focus.SetActive(true);
        }

    }
}
