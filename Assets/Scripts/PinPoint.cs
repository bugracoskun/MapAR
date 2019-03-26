using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinPoint : MonoBehaviour
{
    public GameObject objects;
    public void Toggle_Changed(bool newValue)
    {
        if (objects.activeSelf == false)
        {

            objects.SetActive(true);


        }

    }
}
