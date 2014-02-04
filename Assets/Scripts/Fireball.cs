/*
 * Fireball
 * -------->
 * Guides fireball from weapon to crosshair location.
 * 
 */

using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class Fireball : MonoBehaviour {

	private Vector3 target;

	public float StartPush = 5.0f;
	public float Velocity = 5.0f;
	public bool InvertX = false;

	void Start () {
		target = GameObject.FindWithTag("Crosshair").transform.position;
		rigidbody.AddRelativeForce (new Vector3((InvertX ? -StartPush: StartPush) * 0.5f, StartPush, 0), ForceMode.Impulse);
	}

	void Update () {
		// rigidbody.AddRelativeForce (new Vector3(0, 0, Velocity * Time.deltaTime), ForceMode.Acceleration);
		transform.Translate(new Vector3(0, 0, Velocity * Time.deltaTime), Space.Self);
		transform.LookAt(target);
	}
}
