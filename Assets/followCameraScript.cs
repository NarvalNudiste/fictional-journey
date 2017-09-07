using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCameraScript : MonoBehaviour {
	void Update () {
		Transform temp = FindObjectOfType<Camera> ().GetComponent<Transform>();
		if (temp != null) {
			this.transform.position = temp.position;
		}
	}
}
