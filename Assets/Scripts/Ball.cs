using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float launchSpeed = 400f;

	private Rigidbody ball;
	private AudioSource ballSound;

	// Use this for initialization
	void Start () {
		ball = GetComponent<Rigidbody>();
		ballSound = GetComponent<AudioSource> ();
	}

	void FixedUpdate () {
		if (Input.GetKeyDown(KeyCode.Space)){
			LaunchBall ();
		}
	}

	public void LaunchBall () {
		ball.velocity = new Vector3 (0, 0, launchSpeed);
		ballSound.Play ();
	}

}
