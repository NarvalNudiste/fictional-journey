using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	private AudioSource mainMusicPlayer;
	public AudioClip clip;
	void Awake(){
		mainMusicPlayer = this.gameObject.AddComponent<AudioSource> ();
		mainMusicPlayer.clip = Resources.Load ("AmusingSteak") as AudioClip;
		mainMusicPlayer.volume = 0.2f;
		mainMusicPlayer.loop = true;
		mainMusicPlayer.Play ();
	}
}
