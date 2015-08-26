using UnityEngine;
using System.Collections;

public class MountainNode : MonoBehaviour {

	public MountainNode[] children;
	public MountainNode parent;
	private bool climbable = true;
	private int numberOfRocksInAvalanche = 5;
	private ArrayList rockArray = new ArrayList();
	private ArrayList snowballs;

	void Start() {
	}

	public MountainNode getParent() {
		return parent;
	}

	void OnMouseOver(){
		if (Input.GetMouseButtonDown (0)) {
			if(climbable) {
				GameObject.Find("Controller").GetComponent<AudioController>().PlayClip("avalanche");
				avalanche();
			}
		}
	}

	public bool isClimbable() {
		return climbable;
	}

	public MountainNode getRandomChild() {
		System.Random random = new System.Random();
		if (children.Length != 0) {
			return children [random.Next (children.Length - 1)];
		} else {
			return null;
		}
	}

	private void avalanche() {
		climbable = false;
		snowballs = GetComponent<Snowspawn> ().getSnowballs ();

		foreach(GameObject g in snowballs) {
			g.transform.localScale = g.transform.localScale*2;
			Rigidbody rb = g.GetComponent<Rigidbody>();
			rb.constraints = RigidbodyConstraints.None;
		}

		//Debug.Log ("Get past taking onstriant off");
		StartCoroutine (destroyAvalanche ());
		//Debug.Log ("get pas open avalance coroute");
		StartCoroutine (regen());
		//Debug.Log ("get pas open regen coroute");
		//generateRocks ();
		foreach(MountainNode node in children) {
			node.avalanche();
		}
	}

	private IEnumerator regen() {
		yield return new WaitForSeconds(10);
		GetComponent<Snowspawn> ().GenerateSnow ();
		climbable = true;
	}

	private void generateRocks() {
		//ParticleSystem parts = GetComponent<ParticleSystem> ();
		SphereCollider sphere = GetComponent<SphereCollider> ();
		Bounds bounds = sphere.bounds;//find 
		
		for (int i = 0; i < numberOfRocksInAvalanche; i++) {
			Vector3 rockPosition = GeneratePosition (bounds);
			GameObject rock = (GameObject)Instantiate(Resources.Load("rock"));
			rock.transform.position = rockPosition;
			Rigidbody rb = rock.GetComponent<Rigidbody>();
			//rb.AddForce(100,100,100);
			rockArray.Add(rock);
			//Debug.Log ("Generating rock position at:" + rockPosition.ToString());
		}
		
	}

	private Vector3 GeneratePosition(Bounds b) {
		return Random.insideUnitSphere * b.extents.magnitude + transform.position;
		
	}

	IEnumerator destroyAvalanche() {
		yield return new WaitForSeconds(10);
		foreach (GameObject ball in snowballs) {
			Destroy(ball);
		}
	}

}
