using UnityEngine;
using System.Collections;

public class Trash : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Paintable")){
			Destroy(other.gameObject);
	}
	}
}