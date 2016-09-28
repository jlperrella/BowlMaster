using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;


[TestFixture]
public class ActionMasterTest {

	private List<int> pinFalls;
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
	private ActionMaster.Action clean = ActionMaster.Action.Clean;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;

	[SetUp]
	public void Setup () {
		pinFalls = new List<int> ();
	}


	[Test]
	public void T00PassingTest() {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01OneStrikeReturnsEndTurn () {
		pinFalls.Add (10);
		Assert.AreEqual (endTurn, ActionMaster.NextAction (pinFalls));
	}

	[Test]
	public void T02Bowl8ReturnsClean () {
		pinFalls.Add (8);
		Assert.AreEqual (clean,	ActionMaster.NextAction (pinFalls));
	}

	[Test]
	public void T03Bowl28ReturnsEndTurn () {
		int[] rolls = { 2, 8 };
		Assert.AreEqual (endTurn, ActionMaster.NextAction (rolls.ToList()));
	}

	[Test]
	public void T04Bowl010ReturnsEndTurn() {
		int[] rolls = { 0, 10 };
		Assert.AreEqual (endTurn, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T05BowlStrikeSpareReturnsEndTurn() {
		int[] rolls = { 10, 4, 6 };
		Assert.AreEqual (endTurn, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T06CheckRestAtStrikeInLastFrame () {
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };
		Assert.AreEqual (reset, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T07CheckResetAtSpareInLastFrame () {
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9 };
		Assert.AreEqual (reset, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T09EndGameScenario1 () {
		int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2,9 };
		Assert.AreEqual (endGame, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T10GameEndsAtBowl20 () {
		int[] rolls = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		Assert.AreEqual (endGame, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T11StrikeOnBowl19Then5 () {
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10,5};
		Assert.AreEqual (clean, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T12aZeroAndStrikeSkipsABowl () {
		int[] rolls = {0, 10,5};
		Assert.AreEqual (clean, ActionMaster.NextAction(rolls.ToList()));
		}

	[Test]
	public void T1310FrameTurkey () {
		int[] rolls = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,10,10,10};
	
		Assert.AreEqual (endGame, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T1401GivesEndTurn () {
		int[] rolls = {0,1};
		Assert.AreEqual (endTurn, ActionMaster.NextAction(rolls.ToList()));
	}
}

	