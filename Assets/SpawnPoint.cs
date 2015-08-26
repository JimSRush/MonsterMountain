using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {
	public GameObject spawn() {
		GameObject climber = (GameObject)Instantiate(Resources.Load("Climber"), transform.position, Quaternion.identity);
		//climber.transform.parent = transform;
		climber.GetComponent<Climb>().setTarget (gameObject.GetComponent<MountainNode>());
		climber.transform.position = GameObject.Find ("Controller").transform.position;
		return climber;
	}
}
