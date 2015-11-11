using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {
	[SerializeField] float tumble;
	Rigidbody asteroid;

	void Start() {
		asteroid = GetComponent<Rigidbody> ();
		asteroid.angularVelocity = Random.insideUnitSphere * tumble; 
	}
}
