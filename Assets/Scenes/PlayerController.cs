using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {

	public float xMin
			   , xMax
			   , zMin
			   , zMax;

}

public class PlayerController : MonoBehaviour {

	[SerializeField] Boundary boundary;
	[SerializeField] float shipSpeed;
    [SerializeField] float tilt;
	[SerializeField] GameObject boltPrefab;
	[SerializeField] Transform shotSpawn;


	Rigidbody ship;
	Transform shipEnd;
	float moveHorizontal;
	float moveVertical;
	GameObject shot;

	
	void Awake () {
		ship = GetComponent<Rigidbody> ();
	}

	void Update () {
		if(Input.GetButtonDown("Fire1")){
			GameObject bolt = Instantiate (boltPrefab, shotSpawn.position, shotSpawn.rotation) as GameObject;
		}
	}

	void RemoveBolt () {
		Invoke
	}

	void FixedUpdate () {

		// Move ship based on input
		moveHorizontal = Input.GetAxis ("Horizontal") * shipSpeed;
		moveVertical = Input.GetAxis ("Vertical") * shipSpeed;
		ship.velocity = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		// Correct the ship from going out of bounds with clamp
		float newXPosition = Mathf.Clamp (ship.position.x, boundary.xMin, boundary.xMax);
		float newYPosition = Mathf.Clamp(ship.position.z, boundary.zMin, boundary.zMax);
		ship.position = new Vector3 (newXPosition, 0.0f, newYPosition);

		ship.rotation = Quaternion.Euler (0.0f, 0.0f, ship.velocity.x * -tilt);
	}
}
