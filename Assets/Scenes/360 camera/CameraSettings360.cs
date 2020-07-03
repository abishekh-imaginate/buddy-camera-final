﻿using System;
using UnityEngine;

public class CameraSettings360 : MonoBehaviour
{

	public Transform target;
	private float smoothSpeed = 0.125f;
	public Vector3 offset;
	private float angle;
	private float radiusOfRotation;
	private float theta;

	void FixedUpdate()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;
	}
}
