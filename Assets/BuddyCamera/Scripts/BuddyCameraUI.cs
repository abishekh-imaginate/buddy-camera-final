using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyCameraUI : MonoBehaviour
{
    public GameObject buddyCameraObject;
    public GameObject mainCanvasObject;
    public GameObject mainMenuCanvasObject;
    
    void Start()
    {
        mainCanvasObject = transform.Find("Main Canvas").gameObject;
        mainMenuCanvasObject = transform.Find("Main Menu Canvas").gameObject;
    }

    public void OnClickBuddyCameraButton()
    {
        mainCanvasObject.SetActive(false);
        mainMenuCanvasObject.SetActive(true);
        buddyCameraObject.SetActive(true);
    }

    public void OnClickExitBuddyCameraButton()
    {
        mainMenuCanvasObject.SetActive(false);
        buddyCameraObject.SetActive(false);
        mainCanvasObject.SetActive(true);
    }
}
