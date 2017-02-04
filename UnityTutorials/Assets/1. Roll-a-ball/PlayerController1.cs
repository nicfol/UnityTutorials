using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController1 : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private int count;

	public Text countText;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		speed = 10.0f;

		count = 0;
		SetCountText();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHori = Input.GetAxis("Horizontal");
		float moveVert = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHori, 0, moveVert);

		rb.AddForce(movement * speed);
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Pick Up")) {
			Destroy(other.gameObject);
			count++;
			SetCountText();
		}
	}

	void SetCountText () {
		countText.text = "Count: " + count.ToString();
		if(count >= 3) {
			countText.text = "You Win!";
		}
	}


}
