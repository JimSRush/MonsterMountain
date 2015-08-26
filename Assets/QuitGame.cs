using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {
	void OnMouseOver(){
		if (Input.GetMouseButtonDown (0)) {
			Application.Quit();
		}
	}
}
