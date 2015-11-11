using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	
	[SerializeField] float speed;
	Rigidbody rb;
	
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
	}
}
