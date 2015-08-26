using UnityEngine;
using System.Collections;

public class LookAtCamera : MonoBehaviour {

	public Camera cam;
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (cam.transform.position);
	}
}
