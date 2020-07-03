using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public static bool menuOpened = false;
    public GameObject menuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightAlt) || Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (menuOpened)
                CloseMenu();
            else
                OpenMenu();
        }
    }

    void CloseMenu()
    {
        menuUI.SetActive(false);
        menuOpened = false;
    }

    void OpenMenu()
    {
        menuUI.SetActive(true);
        menuOpened = true;
    }
}
