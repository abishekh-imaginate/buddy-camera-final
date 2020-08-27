using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyCameraUI : MonoBehaviour
{
    public GameObject buddyCameraObject;
    public GameObject mainCanvasObject;
    public GameObject mainMenuCanvasObject;
    public GameObject startCaptureCanvas;
    public GameObject stopCaptureCanvas;

    public void OnClickBuddyCameraButton()
    {
        mainCanvasObject.SetActive(false);
        buddyCameraObject.SetActive(true);
        mainMenuCanvasObject.SetActive(true);
        startCaptureCanvas.SetActive(true);
    }

    public void OnClickExitBuddyCameraButton()
    {
        startCaptureCanvas.SetActive(false);
        mainMenuCanvasObject.SetActive(false);
        buddyCameraObject.SetActive(false);
        mainCanvasObject.SetActive(true);
    }

    public void OnClickStartCaptureButton()
    {
        startCaptureCanvas.SetActive(false);
        stopCaptureCanvas.SetActive(true);
    }

    public void OnClickStopCaptureButton()
    {
        stopCaptureCanvas.SetActive(false);
        startCaptureCanvas.SetActive(true);
    } 
}
