using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator2 : MonoBehaviour {

	private Rigidbody rb;

	public float tumble = 5.0f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
