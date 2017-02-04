using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController2 : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValue;

	public float waveWait;
	public float spawnWait;
	public float startWait;

	public int hazardCount;

	public Text scoreText;
	public int score;

	public Text restartText;
	public Text gameoverText;

	private bool gameOver;
	private bool restart;


	void Start () {
		StartCoroutine(SpawnWaves());
		score = 0;
		UpdateScore();

		gameOver = false;
		restart = false;
		restartText.text = "";
		gameoverText.text = "";
	}

	private void Update() {
		if (restart) {
			if(Input.GetKeyDown(KeyCode.R)) {
				//Application.LoadLevel(Application.loadedLevel);
				SceneManager.LoadScene("MainScene");
				gameoverText.text = "";
				restart = false;
			}
		}
	}

	IEnumerator SpawnWaves() {

		yield return new WaitForSeconds(startWait);
		while(true) { 
			for (int i = 0; i < hazardCount; i++) { 
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);

			if(gameOver) {
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	public void AddToScore(int valueToAdd) {
		score += valueToAdd;
		UpdateScore();
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}
	
	public void Gameover() {
		gameoverText.text = "Game Over!";
		gameOver = true;
	}
}
