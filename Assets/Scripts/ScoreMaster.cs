using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreMaster {


	// returns a list of total scores like a scorecard
	public static List<int> ScoreCumulative (List<int> rolls) {
		List<int> cumaltiveScores = new List<int> ();
		int runningTotal = 0;

		foreach (int frameScore in ScoreFrames (rolls)) {
			runningTotal += frameScore;
			cumaltiveScores.Add (runningTotal);
		}
		return cumaltiveScores;
	}


	// return an individual list of frame scores
	public static List<int>	ScoreFrames (List<int> rolls) {
		List<int> frames = new List<int> ();

		for (int i = 1; i < rolls.Count; i += 2) {
			if (frames.Count == 10) {							//PREVENTS 11TH FRAME SCORE
				break;
			}
				
			if (rolls [i-1] + rolls [i] < 10) {					//OPEN FRAME
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
				frames.Add (10 + rolls [i+1]); 					// calculate SPARE bonus
			}
		}
	
		return frames;
	}




}
