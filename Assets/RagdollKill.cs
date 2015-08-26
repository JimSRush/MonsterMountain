using UnityEngine;
using System.Collections;

public class RagdollKill : MonoBehaviour {
	void Start () {
		StartCoroutine(kill());
	}

	IEnumerator kill() {
		yield return new WaitForSeconds (8);
		Destroy (gameObject);
	}
}
