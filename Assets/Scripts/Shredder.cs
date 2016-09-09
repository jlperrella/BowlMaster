using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	void OnTriggerEnter(Collider item) {
		Destroy (item.gameObject);
	}

}
