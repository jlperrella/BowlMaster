using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinZone : MonoBehaviour {

	public Text scoreBoard;
	public int lastStandingCount = -1;
	public bool ballInBox = false;

	private GameManager gameManager;

	private float lastChangeTime;
	private int lastSettledCount = 10;
	private Animator animator;
		
	void Start () {
		animator = FindObjectOfType<PinController> ().GetComponent<Animator>();
		gameManager = GameObject.FindObjectOfType<GameManager>();
	}

	void Update () {
		scoreBoard.text = CountStandingPins ().ToString ();
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
		
	public int CountStandingPins () {
		int standingPins = 0;
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.IsStanding ()) {
				standingPins += 1;
			}
		}
		return standingPins;
	}
		
	public void UpdateStandingAndSettle () {
		int currentFallen = CountStandingPins ();

		if (currentFallen != lastStandingCount) {
			lastChangeTime = Time.time;
			lastStandingCount = currentFallen;
			return;
		}
		float settleTime = 3f;
		if ((Time.time - lastChangeTime) > settleTime) {
			PinsSettled ();
		}

	}
	public void PinsSettled () {
		int standing = CountStandingPins ();
		int pinFall = lastSettledCount - standing;
		lastSettledCount = CountStandingPins ();
		gameManager.Bowl (pinFall);
		ballInBox = false;
		lastStandingCount = -1;
	}
		
	public void PerformAction (ActionMasterOld.Action action) {
		if (action == ActionMasterOld.Action.Clean) {
			animator.SetTrigger ("CleanPins");
		}
		else if (action  == ActionMasterOld.Action.EndTurn) {
			animator.SetTrigger ("ResetPins");
			lastSettledCount = 10;
		}
		else if (action  == ActionMasterOld.Action.Reset) {
			animator.SetTrigger ("ResetPins");
			lastSettledCount = 10;
		}
		else if (action == ActionMasterOld.Action.EndGame) {
			print ("GAME OVER");
		}
	}
}
