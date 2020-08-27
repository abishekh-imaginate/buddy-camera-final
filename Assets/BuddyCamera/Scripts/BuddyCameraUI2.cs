using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyCameraUI2 : MonoBehaviour
{
    public GameObject buddyCameraObject;
    public GameObject mainMenuCanvasObject;
    public GameObject startCaptureCanvas;
    public GameObject stopCaptureCanvas;

    public void OnClickBuddyCameraButton()
    {
        mainMenuCanvasObject.SetActive(true);
        buddyCameraObject.SetActive(true);
        startCaptureCanvas.SetActive(true);
    }

    public void OnClickExitBuddyCameraButton()
    {
        startCaptureCanvas.SetActive(false);
        buddyCameraObject.SetActive(false);
        mainMenuCanvasObject.SetActive(false);
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
