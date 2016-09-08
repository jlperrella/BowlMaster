using UnityEngine;
using System.Collections;

public class PinZone : MonoBehaviour {

	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = FindObjectOfType<Ball> ();
	}
		
	void OnTriggerEnter (Collider ballCollision) {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			ball.GetComponent<Rigidbody> ().useGravity = false;
		}
	}
}
