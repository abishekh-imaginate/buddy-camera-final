using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject canvasObject;
    public GameObject notificationObject;
    public GameObject minimapObject;
    public GameObject buddyCameraButton;
    public GameObject menuButton;
    public GameObject menu;
    public GameObject drone;
    public GameObject advancedMenu;
    private List<Renderer> avatarRenderers = new List<Renderer>();
    private bool decision;

    void Start()
    {
        foreach (GameObject avatarParent in GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[])
            if (avatarParent.CompareTag("Avatar") & avatarParent.GetComponent<Renderer>() != null)
                avatarRenderers.Add(avatarParent.GetComponent<Renderer>());
    }

    public void setDecisionYes()
    {
        notificationObject.SetActive(!notificationObject.activeSelf);
        menuButton.SetActive(!menuButton.activeSelf);
        minimapObject.SetActive(!minimapObject.activeSelf);
    }

    public void setDecisionNo()
    {
        notificationObject.SetActive(!notificationObject.activeSelf);
    }

    public void ToggleBuddyCameraButton()
    {
        if (!minimapObject.activeSelf)
            notificationObject.SetActive(!notificationObject.activeSelf);
        else
        {
            menuButton.SetActive(!menuButton.activeSelf);
            minimapObject.SetActive(!minimapObject.activeSelf);
        }
    }

    public void ToggleMenuVisibility()
    {
        menu.SetActive(!menu.activeSelf);
        menuButton.SetActive(!menuButton.activeSelf);
        buddyCameraButton.SetActive(!buddyCameraButton.activeSelf);
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
