using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreSheet : MonoBehaviour {

	public Text[] rollTexts, frameTexts;

	public void fillRollCard (List<int> rolls) {
		string scoresString = FormatRolls (rolls);
		for (int i = 0; i < scoresString.Length; i++) {
			rollTexts [i].text = scoresString [i].ToString ();
		}
	}

	public void fillFrames (List<int> frames) {
		for (int i = 0; i > frames.Count; i++) {
			frameTexts [i].text = frames [i].ToString ();
			print ("function called");
		}
	}

	public static string FormatRolls (List<int> rolls) {
		string output = "";
			
		for (int i = 0; i < rolls.Count; i++) {
			int box = output.Length + 1;									//score box 1 to 21

			if (rolls [i] == 0) {											//A score of 0 registers a dash
				output += "-";
			} else if (box % 2 == 0 && rolls [i - 1] + rolls [i] == 10) { 	//SPARE	
				output += "/";
			} else if (box >= 19 && rolls [i] == 10) {						//STIKE IN FRAME 10
				output += "X";
			} else if (rolls [i] == 10) { 									//STRIKE in frames 1-9
				output += "X ";
			} else {
				output += rolls [i].ToString ();							//Normal 1-9 Score
			}
		}
			return output;
	}
}
