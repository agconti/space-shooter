using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	[SerializeField] GameObject asteroid;
	[SerializeField] int hazardCount;
	[SerializeField] float startWait;
	[SerializeField] Vector3 spawnValues;
	[SerializeField] float spawnWait;
	[SerializeField] float waveWait;

	[SerializeField] GUIText scoreText;
	[SerializeField] GUIText restartText;
	[SerializeField] GUIText gameOverText;

	int score;
	bool gameOver = false;
	bool restart = false;

	void Start () {
		score = 0;
		UpdateScore ();

		restartText.text = "";
		gameOverText.text = "";

		SpawnWaves ();
		StartCoroutine (SpawnWaves ());
	}

	void Update () {
		if (restart) {
			if (Input.GetKeyDown(KeyCode.R)){
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	
	IEnumerator  SpawnWaves () {
		yield return new WaitForSeconds (startWait);

		while(true) {
			for (int i = 0; i < hazardCount; i++) {
				float xSpawnPosition = Random.Range (-spawnValues.x, spawnValues.x);
				Vector3 spawnPosition = new Vector3(xSpawnPosition, spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;

				Instantiate (asteroid, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			} 
			yield return new WaitForSeconds(waveWait);

			if (gameOver) {
				restartText.text = "Press 'R' for Restart";
				restart = true; 
				break;
			}
		}
	}

	public void AddScore (int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}

	public void GameOver () {
		gameOverText.text = "Game Over!";
		gameOver = true;
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}
}
