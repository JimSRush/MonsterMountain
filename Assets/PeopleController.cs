using UnityEngine;
using System.Collections;

public class PeopleController : MonoBehaviour {
	
	//public Spawn [] spawnPoints;
	public int maxPeople;//Maximumum number of people in the game
	public SpawnPoint[] spawnPoints; //variable size list of spawn points
	public float spawnRateInSeconds; //a float, spawns a new person betweeo 0-Spawnrange
	private bool okToSpawn = true;
	private ArrayList people = new ArrayList();//people in the game.
	
	// Use this for initialization
	void Start () {
		//start the coroutine	
	}
	
	// Update is called once per frame
	void Update () {
		if (okToSpawn) {
			StartCoroutine(RandomSpawn());
		}
	}
	
	IEnumerator RandomSpawn() {
		//Think of this like a critical section.
		okToSpawn = false;

		float randomTime = Random.Range(0, spawnRateInSeconds);//random time between spawns
		//position in the list where to spawn next
		int randomSpawnLocation = (int)Random.Range(0, spawnPoints.Length);
		yield return new WaitForSeconds(randomTime);

		//spawn a person at a random spawn point between 0 -> count of spawn points
		//add this person to the list of people to keep track of how many there are in game

		GameObject person = spawnPoints[randomSpawnLocation].spawn();
		people.Add(person); //add to the list of people

		okToSpawn = true;
	}
}
