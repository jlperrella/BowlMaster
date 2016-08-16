using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Ball ball;

	private Vector3 offset;


	void Start () {
		offset = transform.position - ball.transform.position;
	}

	void Update () {
		transform.position = ball.transform.position + offset;

		if (transform.position.z >= 1200){
			Debug.Log ("POSITION");
			transform.position = new Vector3(0,22,1200);
		}
	}
}
