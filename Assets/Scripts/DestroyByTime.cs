using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	[SerializeField] float lifeTime;

	void Start () {
		Destroy (gameObject, lifeTime);
	}
}
