using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	[SerializeField] GameObject asteroidExplosion;
	[SerializeField] GameObject playerExplosion;
	
	void OnTriggerEnter (Collider other) {

		if (other.CompareTag("Boundary")) {
			return; 
		}

		if (other.CompareTag ("Player")) {
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation); 
		}

		Instantiate (asteroidExplosion, transform.position, transform.rotation);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
