using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;

public class BuddyCamera : MonoBehaviour
{
	private Camera buddyCam;
	private Vector3 offset = new Vector3(0.0f, 2.5f, 2.5f);
	private float FOV = 60.0f;
	private float angle;

	//public bool useCustomUI = false;
	private List<Renderer> avatarRenderers = new List<Renderer>();
	private int presetViewNumber = 0;

	public Transform target;
	public float smoothSpeed = 0.1f;
	public RenderTexture buddyCameraRenderTexture;
	public GameObject droneObject;
	public Button droneVisibilityButton;
	public string avatarTag;
	public Button avatarVisibilityButton;
	public Slider distanceSlider;
	public Slider angleSlider;
	public Slider fieldOfViewSlider;
	public Button changeViewButton;

	void Start()
	{
		buddyCam = gameObject.GetComponent<Camera>();
		buddyCam.targetTexture = buddyCameraRenderTexture;
		droneObject = transform.Find("Drone").gameObject;

		if (avatarTag.Length != 0)
			foreach (GameObject avatarParent in GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[])
				if (avatarParent.CompareTag(avatarTag) & avatarParent.GetComponent<Renderer>() != null)
					avatarRenderers.Add(avatarParent.GetComponent<Renderer>());

		if (droneVisibilityButton)
			droneVisibilityButton.onClick.AddListener(OnClickDroneVisibilityButton);
		if (avatarVisibilityButton)
			avatarVisibilityButton.onClick.AddListener(OnClickAvatarVisibilityButton);
		if (distanceSlider)
			distanceSlider.onValueChanged.AddListener(delegate { OnValueChangeDistanceSlider(); });
		if (angleSlider)
			angleSlider.onValueChanged.AddListener(delegate { OnValueChangeAngleSlider(); });
		if (fieldOfViewSlider)
			fieldOfViewSlider.onValueChanged.AddListener(delegate { OnValueChangeFieldOfViewSlider(); });
		if (changeViewButton)
			changeViewButton.onClick.AddListener(OnClickChangeViewButton);
	}

	void FixedUpdate()
	{
		//update position of the buddy camera
		float radiusOfRotation = Mathf.Sqrt(Mathf.Pow(offset.x, 2) + Mathf.Pow(offset.z, 2));
		float theta = Mathf.Atan(offset.z / offset.x);
		Vector3 newOffset = new Vector3(radiusOfRotation * Mathf.Cos(angle + theta), offset.y, radiusOfRotation * Mathf.Sin(angle + theta));
		Vector3 desiredPosition = target.position + newOffset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;

		//update Field of View of the camera
		buddyCam.fieldOfView = FOV;

		//look at target
		transform.LookAt(target);
	}

	//makes the drone visible or invisible
	public void OnClickDroneVisibilityButton()
	{
		droneObject.SetActive(!droneObject.activeSelf);
	}

	//makes the avatars visible or invisible
	public void OnClickAvatarVisibilityButton()
	{
		foreach (Renderer renderer in avatarRenderers)
			renderer.enabled = !renderer.enabled;
	}

	//gets the value of the idstance slider
	public void OnValueChangeDistanceSlider()
	{
		offset.y = distanceSlider.value;
		offset.z = distanceSlider.value;
	}

	//gets the value of the angle slider
	public void OnValueChangeAngleSlider()
	{
		angle = angleSlider.value;
	}

	//gets the value for the Field of View (zoom)
	public void OnValueChangeFieldOfViewSlider()
	{
		FOV = fieldOfViewSlider.value;
	}

	//changes the distance and angle values according to the preset camera views
	public void OnClickChangeViewButton()
	{
		if (presetViewNumber == 0)
		{
			distanceSlider.value = 2.0f;
			angleSlider.value = 0.0f;
			presetViewNumber++;
		}
		else if (presetViewNumber == 1)
		{
			distanceSlider.value = 2.0f;
			angleSlider.value = 3.14f;
			presetViewNumber++;
		}
		else if (presetViewNumber == 2)
		{
			distanceSlider.value = 2.0f;
			angleSlider.value = 1.57f;
			presetViewNumber++;
		}
		else if (presetViewNumber == 3)
		{
			distanceSlider.value = 4.0f;
			angleSlider.value = 0.0f;
			presetViewNumber++;
		}
		else if (presetViewNumber == 4)
		{
			distanceSlider.value = 4.0f;
			angleSlider.value = 3.14f;
			presetViewNumber++;
		}
		else if (presetViewNumber == 4)
		{
			distanceSlider.value = 7.0f;
			angleSlider.value = 0.0f;
			presetViewNumber++;
		}
		else if (presetViewNumber == 5)
		{
			distanceSlider.value = 7.0f;
			angleSlider.value = 3.14f;
			presetViewNumber = 0;
		}
	}
}