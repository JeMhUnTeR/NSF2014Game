/*
 * Player Motion Temp
 * ------------------>
 * Moves object rigidbody along the xz plane using the axes Horizontal and Vertical.
 * 
 */

using UnityEngine;
using System.Collections;

public class PlayerMotionTemp : MonoBehaviour {

	public float Speed = 100.0f;

	void FixedUpdate () {
		float x = Input.GetAxis ("Horizontal");
		float z = Input.GetAxis ("Vertical");
		transform.Translate(new Vector3 (x, 0, z) * Time.deltaTime * Speed, Space.Self);
	}
}
