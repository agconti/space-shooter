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

	int score;

	void Start () {
		score = 0;
		UpdateScore ();

		SpawnWaves ();
		StartCoroutine (SpawnWaves ());
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
		}
	}

	public void AddScore (int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}
}
