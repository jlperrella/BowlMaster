using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinZone : MonoBehaviour {

	public Text scoreBoard;
	public int lastStandingCount = -1;

	private bool ballInBox = false;
	private float lastChangeTime;

		
	void Update () {
		scoreBoard.text = CountStanding ().ToString ();
		if (ballInBox == true) {
			scoreBoard.color = Color.red;
			UpdateStandingAndSettle ();
		} else {
			scoreBoard.color = Color.green;
		}
	}
		
	void OnTriggerEnter (Collider ballEnterBox) {
		Ball ball = ballEnterBox.gameObject.GetComponent<Ball> ();
		if (ball) {
			ballInBox = true;
		}
	}

	void OnTriggerExit (Collider pinExitBox) {
		Pin pin = pinExitBox.gameObject.GetComponent<Pin> (); 
		if (pin) {
			Destroy (pin.gameObject);
		}
	}
		
	public int CountStanding () {
		int standing = 0;
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.IsStanding ()) {
				standing++;
			}
		}
		return standing;
	}
		
	void UpdateStandingAndSettle () {
		int currentStanding = CountStanding ();

		if (currentStanding != lastStandingCount) {
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}
		float settleTime = 3f;
		if ((Time.time - lastChangeTime) > settleTime) {
			PinsSettled ();
		}

	}
	void PinsSettled () {
		ballInBox = false;
		lastStandingCount = -1;
		Ball ball = FindObjectOfType<Ball> ();
		ball.ResetBall ();
		ScoreKeeper scoreKeeper = FindObjectOfType<ScoreKeeper> ();
		scoreKeeper.KeepScore ();
	}
}
