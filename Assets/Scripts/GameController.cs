using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	[SerializeField] GameObject asteroid; 
	[SerializeField] Vector3 spawnValues;

	void Start () {
		SpawnWaves ();
	}
	
	void  SpawnWaves () {
		float xSpawnPosition = Random.Range (-spawnValues.x, spawnValues.x);
		Vector3 spawnPosition = new Vector3(xSpawnPosition, spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (asteroid, spawnPosition, spawnRotation);

	}
}
