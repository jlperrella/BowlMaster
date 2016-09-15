using UnityEngine;
using System.Collections;

public class PinController : MonoBehaviour {

	public GameObject pinsPrefab;
	private GameObject pins;
	private Rigidbody rigidBody;
	private float raiseHeight = 20f;

	public void ResetPins () {
		Instantiate (pinsPrefab, new Vector3(0f,raiseHeight,1829f),Quaternion.identity);
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
		pins = GameObject.Find("Pins");
		Destroy(pins);
	}

}
