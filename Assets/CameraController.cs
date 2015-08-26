using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	/*Basic camer controller, responds to left and right arrows & orbits the mountain at a set distance*/

	public GameObject mountain;//drag in from inspector
	public float rotationSpeed = 300;
	public bool titleConstant = false;

	//TouchEvent variables
	private Vector2 startPosition;

	public void MoveLeft(){
		transform.RotateAround (mountain.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
	}


	public void MoveRight(){
		transform.RotateAround (mountain.transform.position, Vector3.down, rotationSpeed * Time.deltaTime);
	}



	/*Listen for input events*/
	void FixedUpdate () {
		if (titleConstant) {
			MoveLeft();
		}

		if (Input.GetKey("left"))
		    MoveLeft();
		
		if (Input.GetKey("right"))
			MoveRight();

		if (Input.GetKey("a"))
			MoveLeft();
		
		if (Input.GetKey("d"))
			MoveRight();
	
		/*Listen for touch events for iOS*/
		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			//Where did we touch?
			Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
		
			//swap x with y and zero out y for 
			touchDeltaPosition.y = touchDeltaPosition.x;
			touchDeltaPosition.x = 0;
			transform.RotateAround(mountain.transform.position, touchDeltaPosition, rotationSpeed * Time.unscaledDeltaTime);



		}
	
	
	}
}
