/*
 * Crosshair
 * --------->
 * Adjusts crosshair position along the xz plane.
 * 
 */

using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

	void Start () {
	}

	void Update () {
		RaycastHit hit;
		if (Physics.Raycast (Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
			transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
		}
	}
}
