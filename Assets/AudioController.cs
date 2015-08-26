using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioController : MonoBehaviour {
	public AudioClip [] clips;
	public AudioSource source;
	public float volumeScale;


	void Start () {
		PlayClip ("buildSoundtrack");
	}
	

	public void randomScream() {
		System.Random randoe = new System.Random();
		int rand = randoe.Next(4);

		switch (rand) {
		case 0:
			PlayClip ("ScreamOne");
			break;
		case 1:
			PlayClip ("ScreamTwo");
			break;
		case 2:
			PlayClip ("ScreamThree");
			break;
		case 3:
			PlayClip ("ScreamFour");
			break;
		case 4:
			PlayClip ("ScreamFive");
			break;
		}
	}


	//Called externally and passed the name of the clip
	public void PlayClip(string clipName) {
		for (int i = 0; i < clips.Length; i++) {
			//Debug.Log ("The name of the clip is: " + clips[i].ToString ());
			if (clipName.Equals(clips[i].name)) {
				source.PlayOneShot(clips[i], volumeScale);
				//Debug.Log("Playing clip: " + clipName);
			}
		}
	}

	//did this because it seems to garble if you stop then play something else?
	public void playGameOver() {
		for (int i = 0; i < clips.Length; i++) {
			//Debug.Log ("The name of the clip is: " + clips[i].ToString ());
			if (clips[i].name.Equals("gameover")) {
				GameObject.Find("GOAudioSource").GetComponent<AudioSource>().PlayOneShot(clips[i], volumeScale);
				//Debug.Log("Playing clip: " + clipName);
			}
		}
	}
}
