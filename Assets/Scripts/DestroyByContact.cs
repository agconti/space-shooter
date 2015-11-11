using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	[SerializeField] GameObject asteroidExplosion;
	[SerializeField] GameObject playerExplosion;
	[SerializeField] int scoreValue;

	GameController gameController;

	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if(gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}

		if (gameController == null) {
			Debug.Log("Cannot find 'GameController' script");
		}
	}
	
	void OnTriggerEnter (Collider other) {

		if (other.CompareTag("Boundary")) {
			return; 
		}

		if (other.CompareTag ("Player")) {
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}

		gameController.AddScore(scoreValue);
		Instantiate (asteroidExplosion, transform.position, transform.rotation);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
