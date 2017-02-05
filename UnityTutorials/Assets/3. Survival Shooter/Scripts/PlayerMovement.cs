using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6.0f;

	private Vector3 movement;
	private Animator anim;
	private Rigidbody rb;
	private int floorMask;
	private float camRayLength = 100.0f;

	private void Awake() {
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();

		floorMask = LayerMask.GetMask("Floor");
	}

	private void FixedUpdate() {
		float hInput = Input.GetAxisRaw("Horizontal");
		float vInput = Input.GetAxisRaw("Vertical");

		Move(hInput, vInput);
		Turning();
		Animating(hInput, vInput);
	}

	void Move(float h, float v) {
		movement.Set(h, 0, v);
		movement = movement.normalized * speed * Time.deltaTime;

		rb.MovePosition(transform.position + movement);
	}

	void Turning() {
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit;
		
		if(Physics.Raycast(camRay, out hit, camRayLength, floorMask)) {
			Vector3 playerToMouse = hit.point - transform.position;
			playerToMouse.y = 0;

			Quaternion rotation = Quaternion.LookRotation(playerToMouse);
			rb.MoveRotation(rotation);
		}
	}

	void Animating(float h, float v) {
		bool walking = h != 0f || v != 0f;
		anim.SetBool("IsWalking", walking);
	}
}
