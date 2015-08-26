using UnityEngine;
using System.Collections;

public class Snowspawn : MonoBehaviour {

	private ArrayList snowballs = new ArrayList();

	// Use this for initialization
	void Start () {
		GenerateSnow ();
	}

	public void GenerateSnow() {
		foreach (GameObject g in snowballs) {
			Destroy (g);
		}
		snowballs = new ArrayList();
		SphereCollider col = GetComponent<SphereCollider> ();
		Bounds bounds = col.bounds;
		
		for (int i = 0; i < 10; i++) {
			Vector3 rockPosition = GeneratePosition (bounds);
			GameObject rock = (GameObject)Instantiate (Resources.Load ("snowyrock"));
			snowballs.Add(rock);
			rock.transform.position = rockPosition;
			Rigidbody rb = rock.GetComponent<Rigidbody> ();
			rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
		}
	}

	public ArrayList getSnowballs() {
		return snowballs;
	}

	private Vector3 GeneratePosition(Bounds b) {
		return Random.insideUnitSphere * b.extents.magnitude + transform.position;
		//Random.insideUnitCircle
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag.Equals ("snow") || col.gameObject.tag.Equals ("cabin")) {
			Physics.IgnoreCollision(GetComponent<SphereCollider>(), col.collider);
		}
	}
}
