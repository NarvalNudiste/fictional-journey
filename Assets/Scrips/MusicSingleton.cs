using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSingleton : MonoBehaviour {
	private MusicPlayer mp;
	void Awake(){
		if (FindObjectOfType<MusicPlayer> () == null) {
			GameObject musicPlayerGameObject = new GameObject ();
			musicPlayerGameObject.name = "musicPlayer";
			musicPlayerGameObject.AddComponent<MusicPlayer> ();
			musicPlayerGameObject.AddComponent<followCameraScript> ();
			mp = musicPlayerGameObject.GetComponent<MusicPlayer> ();
			DontDestroyOnLoad (mp.gameObject);

		} else {
			mp = FindObjectOfType<MusicPlayer> ();
		}
	}
}
