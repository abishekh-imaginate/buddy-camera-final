using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject menuButton;
    public GameObject menu;
    public GameObject drone;
    public GameObject advancedMenu;
    private List<Renderer> avatarRenderers = new List<Renderer>();

    void Start()
    {
        foreach (GameObject avatarParent in GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[])
            if (avatarParent.CompareTag("Avatar") & avatarParent.GetComponent<Renderer>() != null)
                avatarRenderers.Add(avatarParent.GetComponent<Renderer>());
    }

    public void ToggleMenuVisibility()
    {
        menu.SetActive(!menu.activeSelf);
        menuButton.SetActive(!menuButton.activeSelf);
    }

    public void ToggleAdvMenuVisibility()
    {
        advancedMenu.SetActive(!advancedMenu.activeSelf);
        menu.SetActive(!menu.activeSelf);
    }

    public void ToggleDroneVisibility()
    {
        drone.SetActive(!drone.activeSelf);
    }

    public void ToggleAvatarVisibility()
    {
        foreach (Renderer renderer in avatarRenderers)
            renderer.enabled = !renderer.enabled;
    }
}
