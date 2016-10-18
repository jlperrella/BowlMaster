using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	private List<int> bowls = new List<int> ();
	private ScoreSheet scoreSheet;

	private Ball ball;
	private PinZone pinZone;

	void Start () {
		scoreSheet = GameObject.FindObjectOfType<ScoreSheet> ();
		ball = GameObject.FindObjectOfType<Ball> ();
		pinZone = GameObject.FindObjectOfType<PinZone>();
	}

	public void Bowl (int pinFall) {
		bowls.Add (pinFall);
		ActionMaster.Action nextAction = ActionMaster.NextAction (bowls);
		pinZone.PerformAction (nextAction);
		scoreSheet.fillRollCard (bowls);
		ball.ResetBall ();
	}
}
