using UnityEngine;
using System.Collections;

public class PinController : MonoBehaviour {

	public GameObject pinsPrefab;

	private GameObject pins;
	private GameObject[] individualPinArray;
	private Rigidbody rigidBody;
	private GameObject pinZone;
	private GameObject singlePin;



	void Awake () {
		individualPinArray = GameObject.FindGameObjectsWithTag("pin");
		pins = GameObject.Find ("Pins");
	}

	public void ResetPins () {
		Instantiate (pinsPrefab, new Vector3(0f,20f,1829f),Quaternion.identity);
	}

	public void LiftPins () {
		
		pins.transform.Translate (0f, 25f, 0f);

		foreach (GameObject pin in individualPinArray){
			rigidBody = pin.GetComponent<Rigidbody>();
			rigidBody.useGravity = false;
		}
	}

	public void LowerPins () {
		foreach (GameObject pin in individualPinArray){
			rigidBody = pin.GetComponent<Rigidbody>();
			rigidBody.useGravity = true;
		}
	}

}
