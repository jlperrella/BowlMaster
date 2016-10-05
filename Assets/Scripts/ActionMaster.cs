using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMaster {

	public enum Action {Clean, Reset, EndTurn, EndGame};

	private int[] bowls = new int[21];
	public int bowl = 1;
		
	public static Action NextAction (List<int> pinFalls) {
		ActionMaster am = new ActionMaster ();
		Action currentAction = new Action ();

		foreach (int pinFall in pinFalls) {
			currentAction = am.Bowl (pinFall);
		}
		return currentAction;
	}

	private Action Bowl (int pins) {
		if (pins < 0 || pins > 10) {
			throw new UnityException ("invalid pin count");
		}

		bowls [bowl - 1] = pins;

		if (bowl == 21) {return Action.EndGame;
		}

		if (bowl == 20 && bowls[18] == 10 && pins <= 9 && Bowl21Awarded()) {
			bowl += 1;
			return Action.Clean;
		}
			
		if (bowl >= 19 && Bowl21Awarded ()) {
			bowl += 1;
			return Action.Reset;
		}

		if (bowl == 20 && !Bowl21Awarded()) {
			return Action.EndGame;
		}

			if (bowl % 2 != 0) { //First Bowl in Frame
				if (pins == 10) {
				bowl += 2;
				return Action.EndTurn;
			} 
			else {
				bowl += 1;
				return Action.Clean;
				}
			} 

			if (bowl % 2 == 0) { //Second Bowl in Frame
				bowl += 1;
				return Action.EndTurn;
			}
			
		throw new UnityException ("Not sure what action to return");
	}
		
	private bool Bowl21Awarded () {
		//because bowl count starts at 1, - 1 is required when using bowls[]
		return (bowls [19 - 1] + bowls [20 - 1] >= 10);
	}

}
