using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject notificationObject;
    public GameObject minimapObject;
    public GameObject buddyCameraObject;
    public GameObject videoCaptureObject;
    public GameObject buddyCameraButton;
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

    public void setDecisionYes()
    {
        notificationObject.SetActive(!notificationObject.activeSelf);
        menu.SetActive(!menu.activeSelf);
        minimapObject.SetActive(!minimapObject.activeSelf);
        buddyCameraObject.SetActive(!buddyCameraObject.activeSelf);
        videoCaptureObject.SetActive(!videoCaptureObject.activeSelf);
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
            menu.SetActive(!menu.activeSelf);
            minimapObject.SetActive(!minimapObject.activeSelf);
            buddyCameraObject.SetActive(!buddyCameraObject.activeSelf);
            videoCaptureObject.SetActive(!videoCaptureObject.activeSelf);
        }
    }

    public void ToggleAdvMenuVisibility()
    {
        buddyCameraButton.SetActive(!buddyCameraButton.activeSelf);
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
