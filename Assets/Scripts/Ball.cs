using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector3 launchVector;

	private Rigidbody ball;
	private AudioSource ballSound;
	private Vector3 startPosition = new Vector3(0,20,30);
	public bool inPlay;

	void Start () {
		ball = GetComponent<Rigidbody>();
		BallStartConditions ();
	}

	void Update () {
		BallTimeOut ();
	}

	void BallStartConditions(){
		ball.useGravity = false;
		inPlay = false;
		ball.transform.position = startPosition;
		ball.velocity = Vector3.zero;
		ball.angularVelocity = Vector3.zero;
	}

	public void LaunchBall (Vector3 velocity) {

		if (inPlay == false) {
			ball.velocity = velocity;
			ball.useGravity = true;
			ballSound = GetComponent<AudioSource> ();
			ballSound.Play ();
			inPlay = true;
		}
	}

	public void BallPosition (float xMove) {
		if (inPlay == false) {
			ball.transform.Translate (xMove, 0, 0, Space.World);
			ball.transform.position = new Vector3 (Mathf.Clamp (ball.transform.position.x, -35f, 35f), ball.transform.position.y, ball.transform.position.z);
		} else {
			return;
		}
	}

	public void ResetBall () {
		BallStartConditions ();
	}

	public void BallTimeOut () {
		if(inPlay == true && ball.velocity == Vector3.zero){
			ResetBall();
		}

	}


}
