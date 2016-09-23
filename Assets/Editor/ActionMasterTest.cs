using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;


[TestFixture]
public class ActionMasterTest {

	private ActionMaster actionMaster;
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
	private ActionMaster.Action clean = ActionMaster.Action.Clean;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;

	[SetUp]
	public void Setup () {
		actionMaster = new ActionMaster ();
	}


	[Test]
	public void T00PassingTest() {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01OneStrikeReturnsEndTurn () {
		Assert.AreEqual (endTurn, actionMaster.Bowl(10));
	}

	[Test]
	public void T02Bowl8ReturnsClean () {
		Assert.AreEqual (clean,	actionMaster.Bowl (7));
	}

	[Test]
	public void T03Bowl28ReturnsEndTurn () {
		actionMaster.Bowl (8);
		Assert.AreEqual (endTurn,actionMaster.Bowl(2));
	}

	[Test]
	public void T04Bowl010ReturnsEndTurn() {
		actionMaster.Bowl (0);
		Assert.AreEqual (endTurn, actionMaster.Bowl (10));
	}

	[Test]
	public void T05BowlStrikeSpareReturnsEndTurn() {
		actionMaster.Bowl (10);
		actionMaster.Bowl (4);
		Assert.AreEqual (endTurn, actionMaster.Bowl(6));
	}

	[Test]
	public void T06REMOVEDGameEndsAfter10thFrame() {
	}

	[Test]
	public void T07CheckRestAtStrikeInLastFrame () {
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

		foreach (int roll in rolls) {
			actionMaster.Bowl (roll);
		}
		Assert.AreEqual (reset, actionMaster.Bowl (10));
	}

	[Test]
	public void T08CheckRestAtSpareInLastFrame () {
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

		foreach (int roll in rolls) {
			actionMaster.Bowl (roll);
		}
		actionMaster.Bowl (1);
		Assert.AreEqual (reset, actionMaster.Bowl (9));
	}

	[Test]
	public void T09EndGameScenario1 () {
		int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, };
		foreach (int roll in rolls) {
			actionMaster.Bowl (roll);
		}
		Assert.AreEqual (endGame, actionMaster.Bowl (9));
	}

	[Test]
	public void T10GameEndsAtBowl20 () {
		int[] rolls = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};

		foreach (int roll in rolls) {
			actionMaster.Bowl (roll);
		}
		Assert.AreEqual (endGame, actionMaster.Bowl (1));
	}

	[Test]
	public void T11StrikeOnBowl19Then5 () {
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10};

		foreach (int roll in rolls) {
			actionMaster.Bowl (roll);
		}
		Assert.AreEqual (clean, actionMaster.Bowl (5));
	}

	[Test]
	public void T12aZeroAndStrikeSkipsABowl () {
		int[] rolls = {0, 10,};
		foreach (int roll in rolls) {
			actionMaster.Bowl (roll);
		}
		Assert.AreEqual (clean, actionMaster.Bowl (5));
		}

	[Test]
	public void T1310FrameTurkey () {
		int[] rolls = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};

		foreach (int roll in rolls) {
			actionMaster.Bowl (roll);
		}
		Assert.AreEqual (reset, actionMaster.Bowl (10));
		Assert.AreEqual (reset, actionMaster.Bowl (10));
		Assert.AreEqual (endGame, actionMaster.Bowl (10));
	}
}

	