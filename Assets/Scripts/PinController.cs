using UnityEngine;
using System.Collections;

public class PinController : MonoBehaviour {

	public GameObject pinsPrefab;
	private GameObject pins;

	public void ResetPins () {
		Instantiate (pinsPrefab, new Vector3(0f,20f,1829f),Quaternion.identity);
	}

	public void LiftPins () {
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.LiftStanding ();
		}
	}

	public void LowerPins () {
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.LowerStanding ();
		}
	}

	public void DestroyDuplicatePinArray () {
		pins = GameObject.FindGameObjectWithTag("pinArray");
		Destroy(pins);
	}

}
