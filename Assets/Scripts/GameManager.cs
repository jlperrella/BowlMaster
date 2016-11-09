using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	private List<int> rolls = new List<int> ();
	private ScoreSheet scoreSheet;

	private Ball ball;
	private PinZone pinZone;

	void Start () {
		scoreSheet = GameObject.FindObjectOfType<ScoreSheet> ();
		ball = GameObject.FindObjectOfType<Ball> ();
		pinZone = GameObject.FindObjectOfType<PinZone>();
	}

	public void Bowl (int pinFall) {
		try {
			rolls.Add (pinFall);
			pinZone.PerformAction (ActionMasterOld.NextAction (rolls)); //code change
			scoreSheet.fillRollCard (rolls);
			scoreSheet.fillFrames (ScoreMaster.ScoreTotal(rolls));
			ball.ResetBall ();
		} catch {
			Debug.LogWarning ("error in bowl");
		}
	}
}
