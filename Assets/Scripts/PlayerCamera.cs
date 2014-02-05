/*
 * Player Camera
 * ------------->
 * Controls Player Camera to follow Player-tagged object.
 * Handles mouse input for camera and player rotation.
 * 
 */

using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Camera))]
public class PlayerCamera : MonoBehaviour {

	private Transform Player;			// would be type Animator after character change
	// private Transform Crosshair;
	private Transform CameraFollow;		// camera target transform (camera's target position)
	private Transform CameraFollowRig;	// camera target transform rig

	public float CameraSmoothing = 5.0f;
	public float CameraForwardAdjust = 3.0f;

	public float CameraRigMaxRotationX = 90.0f;
	public float CameraRigMinRotationX = 15.0f;

	public float MouseSensitivityX = 150.0f;
	public float MouseSensitivityY = 50.0f;
	public bool invertX = false;
	public bool invertY = true;

	void Start () {
		// get tagged objects
		Player = GameObject.FindWithTag("Player").transform;
		// Crosshair = GameObject.FindWithTag("Crosshair").transform;
		CameraFollow = GameObject.FindWithTag("CameraFollow").transform;
		CameraFollowRig = GameObject.FindWithTag("CameraFollowRig").transform;
	}

	void Update () {
		
		/*=======================================
		=            Camera Rotation            =
		=======================================*/

		// get mouse input
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = Input.GetAxis("Mouse Y");

		// handle inverted inputs
		if (invertX) mouseX = -mouseX;
		if (invertY) mouseY = -mouseY;

		// rotate player along the x and y
		if (true) {
			Player.Rotate(Vector3.up * mouseX * Time.deltaTime * MouseSensitivityX, Space.Self);
			CameraFollowRig.Rotate(new Vector3(1, 0, 0) * mouseY * Time.deltaTime * MouseSensitivityY, Space.Self);
		}

		/**
		
			TODO:
			- clamp CameraFollowRig x rotation
		
		**/
		

		// (temp) look at player
		transform.LookAt(Player);	// this is the ideal rotation. Smoothen.
		Quaternion rot = Quaternion.identity;
		rot.eulerAngles = new Vector3(transform.rotation.eulerAngles.x - CameraForwardAdjust,
			transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
		transform.rotation = rot;

		/*=======================================
		=            Camera Position            =
		=======================================*/
		
		// smooth target follow
		float xPos = Mathf.Lerp (transform.position.x, CameraFollow.position.x, Time.deltaTime * CameraSmoothing);
		float yPos = Mathf.Lerp (transform.position.y, CameraFollow.position.y, Time.deltaTime * CameraSmoothing);
		float zPos = Mathf.Lerp (transform.position.z, CameraFollow.position.z, Time.deltaTime * CameraSmoothing);

		// set camera position
		transform.position = new Vector3(xPos, yPos, zPos);
	}
}
