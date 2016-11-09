using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ScoreMaster {

	// returns a list of total scores like a scorecard
	public static List<int> ScoreTotal (List<int> rolls) {
		List<int> totalScore = new List<int> ();
		int runningTotal = 0;

		foreach (int frameScore in ScoreFrames (rolls)) {
			runningTotal += frameScore;
			totalScore.Add (runningTotal);
		}
		return totalScore;
	}

	// return an individual list of frame scores
	public static List<int>	ScoreFrames (List<int> rolls) {
		List<int> frames = new List<int> ();

		//index i points to second bowl of frame
		for (int i = 1; i < rolls.Count; i += 2) {
			if (frames.Count == 10) {							//PREVENTS 11TH FRAME SCORE
				break;
			}
				
			if (rolls [i-1] + rolls [i] < 10) {					//NORMAL FRAME
				frames.Add (rolls [i - 1] + rolls [i]);
			}

			if (rolls.Count - i <= 1) {							//INSUFFICIENT ROLL COUNT TO CALCULATE
				break;
			}

			if (rolls [i-1] == 10) {							// STRIKE -- FRAME HAS ONLY 1 BOWL
				i--;		
				frames.Add (10 + rolls [i+1] + rolls [i+2]);
			}

			else if (rolls [i-1] + rolls [i] == 10){
				frames.Add (10 + rolls [i+1]); 					// CALCULATES SPARE BONUS
			}
		}
	
		return frames;
	}




}
