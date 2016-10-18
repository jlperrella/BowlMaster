using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreSheet : MonoBehaviour {

	public Text[] rollTexts, frameTexts;
	private GameObject[] framePanels;

	// Use this for initialization
	void Start () {
		framePanels = GameObject.FindGameObjectsWithTag("framePanel");
		rollTexts [0].text = "X";
		frameTexts [0].text = "0";
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void fillRollCard (List<int> rolls) {
		rolls[-1] =1;
	}
}
