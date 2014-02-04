using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public Object Fireball;
	public string Key = "Fire1";

	void Update () {
		if (Input.GetButtonDown (Key)) {
			Instantiate(Fireball, transform.position, transform.rotation);
		}
	}
}
