using UnityEngine;
using System.Collections;

public class TitleSounds : MonoBehaviour {
	public AudioClip background;
	public AudioSource source;
	void Start () {
		source.PlayOneShot (background);
	}
}
