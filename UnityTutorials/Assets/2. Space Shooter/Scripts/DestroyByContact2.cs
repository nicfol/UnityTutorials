using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact2 : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;

	public GameObject gameControllerObject;
	public GameController2 gameController;

	private void Start() {
		gameControllerObject = GameObject.FindWithTag("GameController");
		gameController = gameControllerObject.GetComponent<GameController2>();
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary") { 
			return;
		} else if (other.tag == "Player") {
			Instantiate(playerExplosion, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.0f), transform.rotation);
			gameController.Gameover();
		}

		Instantiate(explosion, transform.position, transform.rotation);


		gameController.AddToScore(10);
		Destroy(gameObject);
		Destroy(other.gameObject);

	}

}
