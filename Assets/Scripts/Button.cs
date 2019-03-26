using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject Query;
    public GameObject WayPoint;
    public void Direction_Appear()
    {
        if (WayPoint.activeSelf == true)
        {
            Query.SetActive(true);
        }

    }
}
