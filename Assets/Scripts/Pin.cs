using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	private float standingThresholdA = 15f;
	private float standingThresholdB = 345f;

	public bool IsStanding () {
		Vector3 rotationInEuler = transform.rotation.eulerAngles;
		float xTilt = Mathf.Abs (rotationInEuler.x);
		float zTilt = Mathf.Abs (rotationInEuler.z);
		if ((xTilt < standingThresholdA || xTilt > standingThresholdB) && (zTilt < standingThresholdA || zTilt > standingThresholdB)) {
			return true;
		} 
		else {
			return false;
		}
	}
}
