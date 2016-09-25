using UnityEngine;
using System.Collections;
using System;

// This class will control the player camera. It will be a 1st person, mouse controlled.
// I used this turotial to make this: https://www.youtube.com/watch?v=3JsuldsGuNw&index=4&list=WL

public class MouseCamera : MonoBehaviour {

	public float lookSensitivity = 5f;	//Allows for a more fluid movement with thr mouse
	public float yRotation;				//Target rotations, that we can use that allows for the player to turn at set areas
	public float xRotation;
	public float currentYRotation;		//The current rotation that the player is at.
	public float currentXRotation;
	public float yRotationV;			//The speed that the rotation is
	public float xRotationV;
	public float lookSmoothDamp = 0.1f;		//How smooth the move will be

	void Update()
	{
		yRotation += Input.GetAxis("Mouse X") * lookSensitivity;
		xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;

		xRotation = Mathf.Clamp(xRotation, - 90,90);

		currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, ref xRotationV, lookSmoothDamp);
		currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationV, lookSmoothDamp);

		transform.rotation = Quaternion.Euler(currentXRotation,currentYRotation, 0);
	}
}
