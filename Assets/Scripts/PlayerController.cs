using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Animator animator;

	public float DirectionDampTime = 0.25f;
	public float SpeedMulitplier = 3.0f;

	void Start () {
		animator = GetComponent<Animator>();
	}

	void Update () {
		if (animator) {
			// get current animation state
			// AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

			// get input
			float h = Input.GetAxis("Horizontal");
			float v = Input.GetAxis("Vertical");

			// move animator based on input
			animator.SetFloat("Speed", h + v);
			animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);
		}
	}

	void OnAnimatorMove () {
		Vector3 rot = transform.rotation.eulerAngles;
		rot.y += animator.GetFloat("Direction") * Time.deltaTime * 90f;
		Quaternion rotq = Quaternion.identity;
		rotq.eulerAngles = rot;
		transform.rotation = rotq;
	
		transform.Translate(Vector3.forward * animator.GetFloat("Speed") * Time.deltaTime * SpeedMulitplier, Space.Self);

	}
}
