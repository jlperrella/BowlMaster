using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	private PinController swiper;
	private PinZone pinZone;
	private bool firstBall = true;


	void Start() {
		swiper = FindObjectOfType<PinController> ();
		pinZone = FindObjectOfType<PinZone> ();
	}


	public void KeepScore () {
		
		if (firstBall == true) {
			if (pinZone.CountStanding () > 0) {
				swiper.GetComponent<Animator> ().SetTrigger ("CleanPins");
				firstBall = false;
				return;
			} else {
				swiper.GetComponent<Animator> ().SetTrigger ("ResetPins");
				firstBall = true;
				return;
			} 
		}
		else {
			swiper.GetComponent<Animator> ().SetTrigger ("ResetPins");
				firstBall = true;
			return;
		}
	}
}
