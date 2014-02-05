/*
 * Crosshair
 * --------->
 * Adjusts crosshair position along the xz plane.
 * 
 */

using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

	public bool visible = true;
	public bool pointer = false;

	public bool focus = false;
	private float scale = 1.0f;
	private float targetScale = 1.0f;
	private float focusScale = 3.0f;

	void Update () {
		if (visible && pointer) {
			renderer.enabled = true;
			RaycastHit hit;
			if (Physics.Raycast (Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
				transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
			}
		} else if (pointer) {
			renderer.enabled = false;
		} else if (focus) {
			targetScale = focusScale;
		} else {
			targetScale = 1.0f;
		}

		if (!pointer) {
			scale = Mathf.Lerp(scale, targetScale, Time.deltaTime * 5f);
			transform.localScale = new Vector3(scale, scale, 1);
		}
	}
}
