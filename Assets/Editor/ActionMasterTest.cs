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
	public void T0610thFrameHasBonusTurn() {
		
	}
}
	