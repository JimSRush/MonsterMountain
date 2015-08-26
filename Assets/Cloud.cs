using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {
	public GameObject pivot;//drag in from inspector
	public float rotationSpeed;
	public bool left;

	public void MoveLeft(){
		transform.RotateAround (pivot.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
	}
	
	public void MoveRight(){
		transform.RotateAround (pivot.transform.position, Vector3.down, rotationSpeed * Time.deltaTime);
	}

	/*Listen for input events*/
	void FixedUpdate () {
		if (left) {
			MoveLeft();
		} else {
			MoveRight();
		}
		transform.LookAt (pivot.transform.position);
	}

}
