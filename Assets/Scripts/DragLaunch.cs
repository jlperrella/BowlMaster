using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

	public Camera mainCamera;

	private Ball ball;
	private float clickStartPosition, clickEndPosition;
	private float clickStart, clickEnd;
	private float swipeDistance;
	private float swipeTime;
	private float swipeSpeed;
	private Vector3 newLaunchVector;

	void Start () {
		ball = GetComponent<Ball> ();
	}
		
	public void DragStart () {
		PointerClickPosition ();
		clickStartPosition = PointerClickPosition ().y;
		clickStart = Time.time;
	}
		
	public void DragEnd () {
		PointerClickPosition ();
		clickEndPosition = PointerClickPosition ().y;
		float launchXValue = PointerClickPosition ().x * 2; // *2 to increase challenge in getting ideal x coordinate
		clickEnd = Time.time;
		swipeTime = clickEnd - clickStart;
		swipeDistance = clickEndPosition - clickStartPosition;
		swipeSpeed = swipeDistance / swipeTime * 1.5f; //*2 to increase speed to keep up with increased gravity
		newLaunchVector = new Vector3 (launchXValue, 0, swipeSpeed);
		ball.LaunchBall (newLaunchVector);
	}

	//gets pixel coordinates from click and returns world unit click position
	public Vector2 PointerClickPosition () {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCam = 327f;
		Vector3 pixelToUnits = new Vector3 (mouseX, mouseY, distanceFromCam);
		Vector2 mousePosition = mainCamera.ScreenToWorldPoint (pixelToUnits);
		return mousePosition;
	}
}
