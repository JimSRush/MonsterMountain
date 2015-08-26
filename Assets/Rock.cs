using UnityEngine;
using System.Collections;


/*When the rock is spawned, we want it to fall like snow*/
public class Rock : MonoBehaviour {

	void Update() {
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.AddForce (Vector3.down);
	}
}
