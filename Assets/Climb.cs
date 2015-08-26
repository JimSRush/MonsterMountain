using UnityEngine;
using System.Collections;

public class Climb : MonoBehaviour {

	private MountainNode next;
	private float climbSpeed = 1;
	private bool falling = false;
	//private bool nextFallSet = false;
	private Vector3 aboveTheSnowVector;
	private Vector3 mountPos;

	// Use this for initialization
	void Start () {
		//next = GameObject.Find ("Summit").GetComponent<MountainNode>();
		mountPos = next.transform.position;
		aboveTheSnowVector = next.gameObject.transform.position;
		aboveTheSnowVector.x = next.gameObject.transform.position.x + 0.4f; 
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.LookAt (mountPos);

		if (!next.isClimbable() && !falling) {
			falling = true;
			gameObject.AddComponent<Rigidbody>();
			GetComponent<Rigidbody>().AddForce(new Vector3(0,50,0));
			GameObject.Find ("Controller").GetComponent<AudioController>().randomScream();
			Instantiate (Resources.Load ("ClimberRag"), transform.position, Quaternion.identity);
			Destroy (gameObject);
			//StartCoroutine(kill());
		}

		if (!falling && Vector3.Distance (transform.position, aboveTheSnowVector) < 0.5f){
			if (next.getParent () != null) {
				next = next.getParent();
				mountPos = next.transform.position;
				//transform.rotation = Quaternion.AngleAxis (90, Vector3.up) * transform.rotation;
				aboveTheSnowVector = next.gameObject.transform.position;
				aboveTheSnowVector.x = next.gameObject.transform.position.x + 0.4f; 
				if(next.tag.Equals("summit")) {
					GameObject.Find("Controller").GetComponent<GameController>().madeItToTheTop();
				}
			}
		} else {
			transform.position = Vector3.MoveTowards(transform.position, aboveTheSnowVector, climbSpeed*Time.deltaTime);
		}
	}

	public void setTarget(MountainNode targ) {
		next = targ;
	}

	//IEnumerator kill() {
	//	yield return new WaitForSeconds(10);
	//	Instantiate (Resources.Load ("ClimberRag"), transform.position, Quaternion.identity);
	//	Destroy (gameObject);
	//}
}
