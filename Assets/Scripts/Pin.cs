using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	private float standingThresholdA = 45f;
	private float standingThresholdB = 315f;

	void Start () {
	}

	void Update () {
		print (name + IsStanding ());
	}
	public bool IsStanding () {
		Vector3 rotationInEuler = transform.rotation.eulerAngles;
		float xTilt = Mathf.Abs (rotationInEuler.x);
		float zTilt = Mathf.Abs (rotationInEuler.z);
		if (xTilt < standingThresholdA || xTilt > standingThresholdB) {
			return true;
		} 
		if (zTilt < standingThresholdA || zTilt > standingThresholdB) {
			return true;
		} 
		else {
			return false;
		}
	}
}
