using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController2 : MonoBehaviour {

	private Rigidbody rb;
	private AudioSource audio;
	public float speed = 10.0f;
	public float tilt = 4.0f;

	public Boundary Boundary;

	public GameObject shot;
	public float nextFire = 0.0f;
	public float fireRate = 0.25f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		audio = GetComponent<AudioSource>();
	}

	private void Update() {
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.0f), transform.rotation);
			audio.Play();
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		float moveHori = Input.GetAxis("Horizontal");
		float moveVert = Input.GetAxis("Vertical");
		rb.velocity = new Vector3(moveHori, 0, moveVert) * speed;

		rb.position = new Vector3(
			Mathf.Clamp(rb.position.x, Boundary.xMin, Boundary.xMax), 
			0.0f,
			Mathf.Clamp(rb.position.z, Boundary.zMin, Boundary.zMax)
		);

		rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}
