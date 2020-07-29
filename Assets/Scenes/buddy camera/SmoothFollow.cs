using System;
using UnityEngine;
using UnityEngine.UI;

public class SmoothFollow : MonoBehaviour
{

	public Transform target;
	private float smoothSpeed = 0.1f;

	private Vector3 offset = new Vector3(0.0f, 2.5f, 2.5f);
	private float FOV = 60.0f;
	private float angle;

	private float radiusOfRotation;
	private float theta;

	public Slider distaceSlider;
	public Slider angleSlider;
	private int viewNumber = 0;

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

	public void ChangeCameraView()
	{
		if (viewNumber == 0)
		{
			distaceSlider.value = 2.0f;
			angleSlider.value = 0.0f;
			viewNumber++;
		}
		else if (viewNumber == 1)
		{
			distaceSlider.value = 2.0f;
			angleSlider.value = 3.14f;
			viewNumber++;
		}
		else if (viewNumber == 2)
		{
			distaceSlider.value = 2.0f;
			angleSlider.value = 1.57f;
			viewNumber++;
		}
		else if (viewNumber == 3)
		{
			distaceSlider.value = 4.0f;
			angleSlider.value = 0.0f;
			viewNumber++;
		}
		else if (viewNumber == 4)
		{
			distaceSlider.value = 4.0f;
			angleSlider.value = 3.14f;
			viewNumber++;
		}
		else if (viewNumber == 4)
		{
			distaceSlider.value = 7.0f;
			angleSlider.value = 0.0f;
			viewNumber++;
		}
		else if (viewNumber == 5)
		{
			distaceSlider.value = 7.0f;
			angleSlider.value = 3.14f;
			viewNumber = 0;
		}
	}
}