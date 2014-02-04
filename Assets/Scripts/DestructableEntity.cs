using UnityEngine;
using System.Collections;

public class DestructableEntity : MonoBehaviour {

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "PlayerWeapon") {
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}
}
