using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


	/*This class controls the logic for the game
	 * 
	 * Includes:
	 * Button and event listeners 
	 * A link to the audio controller
	 * A link to the people controller
	 * A gametimer
	 * A number of people who have reached the summit (current game condition is just one, so triggered by the summit itself)
	 * A trigger for two end game conditions (win -- volcano. lose -- people win).
	 * 
	 * 
	 */


	public float gameLength; //Length of the game in minutes
	public AudioController controller;//
	bool isAtTop = false; //Has somone made it to the top?
	public GameObject lavaTop;//drag in from the inspector, we need this location for the endgame code
	public GameObject topMountain;
	public int numberOfLavaRocks = 2;

	// Use this for initialization
	void Start () {
		runTimer ();//start the game timer. duh.
		controller.PlayClip ("ambientMountain");
		//summit = GameObject.Find ("Summit");
		//EndGameWin ();
	}

	//Starts the countdown timer fo the game
	void runTimer(){
		StartCoroutine(countDownToZero(gameLength * 60));//seconds to minutes 	conversion 
		//EndGameWin ();
	}


	//This is the magic that happens in the coroutine	
	IEnumerator countDownToZero(float time) {
		yield return new WaitForSeconds(time);
		EndGameWin ();
		//do the thing/end the game.
	}


	// Update is called once per frame
	void Update () {
		if (isAtTop) {//check the endgame condition
			EndGameLose();
		}
	}

	//Sets the end game condition, called by the people controller
	public void madeItToTheTop() {
		isAtTop = true;
	}


	/*Blows the top off the mountain and spews out lava*/
	void EndGameWin() { 
		//Debug.Log ("The name of the summit is: " + lavaTop.name);
		SphereCollider sphere = lavaTop.GetComponent<SphereCollider> ();//returning a null???
		Bounds b = sphere.bounds;

		for (int i = 0; i< numberOfLavaRocks; i++) {
			Vector3 rockPosition = GeneratePosition (b);
			GameObject rock = (GameObject)Instantiate(Resources.Load("lavarock"));
			//Debug.Log("spawning lava at " + rock.transform.position.ToString());
			rock.transform.position = rockPosition;
		}

		Rigidbody rb = topMountain.GetComponent <Rigidbody> ();
//		Rigidbody rb = topMountain.GetComponent<MeshCollider> ().attachedRigidbody;
		rb.constraints = RigidbodyConstraints.None;//remove the constrains
		Destroy(topMountain.GetComponent<MeshCollider>());
		rb.isKinematic = false;
		//rb.AddRelativeForce (transform.up * 700f);//push up very fast
		rb.AddRelativeForce (new Vector3 (0, 10, 10) * 40f);
		StartCoroutine (win ());
		//rb.AddForce(transform.posio
	}

	private Vector3 GeneratePosition(Bounds b) {
		return Random.insideUnitSphere * b.extents.magnitude + lavaTop.transform.position;
	}

	/*Start game over sequence*/
	void EndGameLose(){
		controller.source.Stop ();
		controller.playGameOver ();
		StartCoroutine(lose ());
	}

	IEnumerator win() {
		yield return new WaitForSeconds (5);
		AutoFade.LoadLevel("Title", 2, 2, Color.white);
	}

	IEnumerator lose() {
		yield return new WaitForSeconds (5);
		AutoFade.LoadLevel("Title", 6, 2, Color.black);
	}
}
