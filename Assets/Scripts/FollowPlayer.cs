using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public float Speed = 1.0f;

	void Update () {
		transform.LookAt(GameObject.FindWithTag("Player").transform);
		transform.Translate(Vector3.forward * Speed * Time.deltaTime, Space.Self);
	}
}
