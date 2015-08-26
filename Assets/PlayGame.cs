using UnityEngine;
using System.Collections;

public class PlayGame : MonoBehaviour {
	void OnMouseOver(){
		if (Input.GetMouseButtonDown (0)) {
			AutoFade.LoadLevel("Main", 2, 2, Color.white);
		}
	}	
}
