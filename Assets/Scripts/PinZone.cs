using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinZone : MonoBehaviour {

	public Text scoreBoard;
	public int lastStandingCount = -1;
	public bool ballInBox = false;

	private float lastChangeTime;
	private int lastSettledCount = 10;
	private ActionMaster actionMaster = new ActionMaster();
	private Animator animator;

		
	void Start () {
		animator = FindObjectOfType<PinController> ().GetComponent<Animator>();
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

		ActionMaster.Action actionInAction = actionMaster.Bowl (pinFall);
	
		if (actionInAction == ActionMaster.Action.Clean) {
			animator.SetTrigger ("CleanPins");
		}
		else if (actionInAction  == ActionMaster.Action.EndTurn) {
			animator.SetTrigger ("ResetPins");
			lastSettledCount = 10;
		}
		else if (actionInAction  == ActionMaster.Action.Reset) {
			animator.SetTrigger ("ResetPins");
			lastSettledCount = 10;
		}
		else if (actionInAction == ActionMaster.Action.EndGame) {
			print ("GAME OVER");
		}

		ballInBox = false;
		lastStandingCount = -1;
		Ball ball = FindObjectOfType<Ball> ();
		ball.ResetBall ();
	}
}
