/*
 * 
 * Player Motion Temp
 * ------------------>
 * Moves object rigidbody along the xz plane using the axes Horizontal and Vertical.
 * 
 */

using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class PlayerMotionTemp : MonoBehaviour {

	public float Speed = 100.0f;
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal");
		float z = Input.GetAxis ("Vertical");
		rigidbody.AddRelativeForce (new Vector3 (x, 0, z) * Time.deltaTime * Speed);
	}
}
