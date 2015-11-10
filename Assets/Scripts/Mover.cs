using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	
	Rigidbody bolt;
	[SerializeField] float boltSpeed;
	
	void Start () {
		bolt = GetComponent<Rigidbody> ();
		bolt.velocity = transform.forward * boltSpeed;
	}
}
