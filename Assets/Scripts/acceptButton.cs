using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class acceptButton : MonoBehaviour
{
    public GameObject route;
    public Text destination;

    public void Direction_Appear()
    {
        if (string.IsNullOrEmpty(destination.text))
        {
            Debug.Log("bir değer girin");
        }
        else
        {
            route.SetActive(true);
        }

    }
}
