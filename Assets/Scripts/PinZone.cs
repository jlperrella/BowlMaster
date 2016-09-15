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
			CheckStanding ();
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
		
		
	int CountStanding () {
		int standing = 0;
		//allows you to access functions on the Pin Script
		// Pin = Pin Script pin = local namespace
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.IsStanding ()) {
				standing++;
			}
		}
		return standing;
	}
		
	void CheckStanding () {
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
	}



}
