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
	private Transform CameraFollow;		// camera target transform (camera's target position)

	/*-----  Camera Variables  ------*/
	public float CameraSmoothing = 5.0f;

	/*-----  Mouse Variables  ------*/
	public float MouseSensitivity = 50.0f;

	void Start () {
		// get tagged objects
		Player = GameObject.FindWithTag("Player").transform;
		CameraFollow = GameObject.FindWithTag("CameraFollow").transform;
	}

	void Update () {
		/*=======================================
		=            Camera Position            =
		=======================================*/
		
		// smooth target follow
		float xPos = Mathf.Lerp(transform.position.x, CameraFollow.position.x, Time.deltaTime * CameraSmoothing);
		float yPos = Mathf.Lerp(transform.position.y, CameraFollow.position.y, Time.deltaTime * CameraSmoothing);
		float zPos = Mathf.Lerp(transform.position.z, CameraFollow.position.z, Time.deltaTime * CameraSmoothing);

		// set camera position
		transform.position = new Vector3(xPos, yPos, zPos);
		
		/*=======================================
		=            Camera Rotation            =
		=======================================*/

		// get mouse input
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = Input.GetAxis("Mouse Y");

		// rotate player based on mouse x movement
		Player.Rotate(Vector3.up * mouseX * Time.deltaTime * MouseSensitivity, Space.World);

		// (temp) look at player
		transform.LookAt(Player);	// this is the ideal rotation. Smoothen.
	}
}
