using UnityEngine;
using System.Collections;

public class ActionMaster {

	public enum Action {Clean, Reset, EndTurn, EndGame};

	//private int[] bowls = new int[21];
	public int bowl = 1;
		

	public Action Bowl (int pins) {
		if (pins < 0 || pins > 10) {
			throw new UnityException ("invalid pin count");
		}

		if (pins == 10) {
			bowl += 2;
			return Action.EndTurn;
		}

		if (bowl % 2 != 0) { //MID FRAME
			bowl += 1;
			return Action.Clean;
		} 

		if (bowl % 2 == 0) { //END FRAME
			bowl += 1;
			return Action.EndTurn;
		}
		throw new UnityException ("Not sure what action to return");
	}
}
