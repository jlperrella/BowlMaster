using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector3 launchVector;
	public bool inPlay;

	private Rigidbody ball;
	private AudioSource ballSound;
	private Vector3 startPosition = new Vector3(0,20,30);
	private PinZone pinZone;
	private Gutter gutter;
	private float ballEntersGutterTime;

	void Start () {
		ball = GetComponent<Rigidbody>();
		BallStartConditions ();
		pinZone = FindObjectOfType<PinZone> ();
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
		if(inPlay == true && ball.velocity.z <= 30){
			pinZone.PinsSettled ();
		}

	}

	void OnCollisionEnter (Collision ballInGutter) {
		gutter = ballInGutter.gameObject.GetComponent<Gutter> ();
		if (gutter && pinZone.ballInBox == false) {
			pinZone.UpdateStandingAndSettle ();
		}
	}
}
