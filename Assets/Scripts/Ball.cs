using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector3 launchVector;

	private Rigidbody ball;
	private AudioSource ballSound;
	private float startPosition;
	private bool inPlay;

	void Start () {
		ball = GetComponent<Rigidbody>();
		ball.useGravity = false;
		inPlay = false;
	}

	public void LaunchBall (Vector3 velocity) {
		ball.velocity = velocity;
		ball.useGravity = true;
		ballSound = GetComponent<AudioSource> ();
		ballSound.Play ();
		inPlay = true;
	}

	public void BallPosition (float xMove) {
		if (inPlay == false) {
			ball.transform.Translate (xMove, 0, 0);
			ball.transform.position = new Vector3 (Mathf.Clamp (ball.transform.position.x, -35f, 35f), ball.transform.position.y, ball.transform.position.z);
		} else {
			return;
		}
	}
}
