using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneVisibility : MonoBehaviour
{
    public GameObject drone;
    public static bool droneVisible = false;

    public void ToggleVisibility()
    {
        if (droneVisible)
        {
            drone.SetActive(false);
            droneVisible = false;
        }
        else
        {
            drone.SetActive(true);
            droneVisible = true;
        }
    }
}
