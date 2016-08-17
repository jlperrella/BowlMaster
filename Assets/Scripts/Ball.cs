using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector3 launchVector;

	private Rigidbody ball;
	private AudioSource ballSound;

	// Use this for initialization
	void Start () {
		ball = GetComponent<Rigidbody>();
		ball.useGravity = false;
	}

	public void LaunchBall (Vector3 velocity) {
		ball.velocity = velocity;
		ball.useGravity = true;
		ballSound = GetComponent<AudioSource> ();
		ballSound.Play ();
	}
}
