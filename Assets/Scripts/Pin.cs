using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	private float standingThresholdA = 265f;
	private float standingThresholdB = 275f;
	private float raiseHeight = 20f;
	private Rigidbody rigidBody;

	public bool IsStanding () {
		Vector3 rotationInEuler = transform.rotation.eulerAngles;
		float xTilt = Mathf.Abs (rotationInEuler.x); // all pis have a rotation of x270 while standing (+/- 5 when wobbling)
		if (xTilt > standingThresholdA && xTilt < standingThresholdB) {
			return true;
		} 
		else {
			return false;
		}
	}

	public void LiftStanding() {
		if (IsStanding ()) {
			transform.Translate (0f, raiseHeight, 0f, Space.World);
			rigidBody = GetComponent<Rigidbody> ();
			rigidBody.useGravity = false;
			transform.rotation = Quaternion.Euler (270f, 0, 0);
		} else {
			return;
		}
	}

	public void LowerStanding () {
		transform.Translate (0f, -raiseHeight, 0f, Space.World);
		rigidBody = GetComponent<Rigidbody> ();
		rigidBody.useGravity = true;
	}
}
