using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ScoreDisplayTest {

	[Test]
	public void T00PassingTest () {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01Bowl1 () { 
		int[] rolls = {1};
		string rollsString = "1";
		Assert.AreEqual (rollsString, ScoreSheet.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T02BowlStrike () {
		int[] rolls = {10};
		string rollString = "X ";
		Assert.AreEqual (rollString, ScoreSheet.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T03Bowl19 () {
		int[] rolls = {1,9};
		string rollString = "1/";
		Assert.AreEqual (rollString, ScoreSheet.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T04Bowl191 () {
		int[] rolls = {1,9,1};
		string rollString = "1/1";
		Assert.AreEqual (rollString, ScoreSheet.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T05BowlXXX () {
		int[] rolls = {10,10,10};
		string rollString = "X X X ";
		Assert.AreEqual (rollString, ScoreSheet.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T06SpareInLastFrame () {
		int[] rolls = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,3};
		string rollString = "1111111111111111111/3";
		Assert.AreEqual (rollString, ScoreSheet.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T07StrikeInLastFrame () {
		int[] rolls = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,10,1,1};
		string rollString = "111111111111111111X11";
		Assert.AreEqual (rollString, ScoreSheet.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T08Bowl0 () {
		int[] rolls = { 0 };
		string rollString = "-";
		Assert.AreEqual (rollString, ScoreSheet.FormatRolls (rolls.ToList ()));
	}
}
