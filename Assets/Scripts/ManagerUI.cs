using UnityEngine;
using System.Collections;

public class ManagerUI : MonoBehaviour {

	private bool complete = false;

	void OnGUI () {
		if (complete) {
			GUI.Box (new Rect (Screen.width * 0.5f - 50f, Screen.height * 0.5f - 15f, 100f, 30f), "Meh.");
		}
	}

	void Update () {
		if (!GameObject.FindObjectOfType(typeof(DestructableEntity))) {
			complete = true;
		} else {
			complete = false;
		}
	}
}
