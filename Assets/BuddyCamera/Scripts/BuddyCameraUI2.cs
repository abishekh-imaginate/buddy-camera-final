using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyCameraUI2 : MonoBehaviour
{
    public GameObject buddyCameraObject;
    public GameObject buddyCameraButton;
    public GameObject menuObject;
    public GameObject startCaptureButton;
    public GameObject stopCaptureButton;

    public void OnClickBuddyCameraButton()
    {
        buddyCameraButton.SetActive(false);
        menuObject.SetActive(true);
        buddyCameraObject.SetActive(true);
    }

    public void OnClickExitBuddyCameraButton()
    {
        buddyCameraObject.SetActive(false);
        menuObject.SetActive(false);
        buddyCameraButton.SetActive(true);
    }

    public void OnClickStartCaptureButton()
    {
        startCaptureButton.SetActive(false);
        stopCaptureButton.SetActive(true);
    }

    public void OnClickStopCaptureButton()
    {
        stopCaptureButton.SetActive(false);
        startCaptureButton.SetActive(true);
    }
}
