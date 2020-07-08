using System;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{

	public Transform target;
	public Camera buddyCamera;
	private float smoothSpeed = 0.125f;

	public Vector3 offset;
	private float FOV;
	private float angle;

	private float radiusOfRotation;
	private float theta;

	void Start()
    {
		buddyCamera = this.GetComponent<Camera>();
		FOV = 60.0f;
    }

	void FixedUpdate()
	{
		radiusOfRotation = Mathf.Sqrt(Mathf.Pow(offset.x, 2) + Mathf.Pow(offset.z, 2));
		theta = Mathf.Atan(offset.z / offset.x);
		Vector3 newOffset = new Vector3(radiusOfRotation * Mathf.Cos(angle + theta), offset.y, radiusOfRotation * Mathf.Sin(angle + theta));
		Vector3 desiredPosition = target.position + newOffset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;
		buddyCamera.fieldOfView = FOV;
		transform.LookAt(target);
	}

    public void SlideDistance(float distance)
    {
        offset.y = distance;
        offset.z = distance;
    }

	public void changeAngle(float sliderAngle)
	{
		angle = sliderAngle;
	}

	public void SlideFieldOfView(float SliderFieldOfView)
    {
		FOV = SliderFieldOfView;
    }
}
