using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float speed = 10.0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(0, -1 * speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(0, speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Rotate(speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.UpArrow))
            transform.Rotate(-1 * speed * Time.deltaTime, 0, 0);
    }
}
