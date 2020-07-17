using System;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{

	public Transform target;
	private float smoothSpeed = 0.125f;

	public Vector3 offset;
	private float FOV = 60.0f;
	private float angle;

	private float radiusOfRotation;
	private float theta;

	void FixedUpdate()
	{
		radiusOfRotation = Mathf.Sqrt(Mathf.Pow(offset.x, 2) + Mathf.Pow(offset.z, 2));
		theta = Mathf.Atan(offset.z / offset.x);
		Vector3 newOffset = new Vector3(radiusOfRotation * Mathf.Cos(angle + theta), offset.y, radiusOfRotation * Mathf.Sin(angle + theta));
		Vector3 desiredPosition = target.position + newOffset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;
		this.GetComponent<Camera>().fieldOfView = FOV;
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
