using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinZone : MonoBehaviour {

	public Text scoreBoard;
	private bool ballInBox = false;

	void Start () {
	}
		
	void Update () {
		scoreBoard.text = CountStanding ().ToString ();
		if (ballInBox == true) {
			scoreBoard.color = Color.red;
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

}
