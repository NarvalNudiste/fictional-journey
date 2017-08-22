using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public Transform player;
    private float lerpSpeed = 0.1f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 target = Vector3.Lerp(this.transform.forward, player.transform.position, lerpSpeed * Time.deltaTime);
        transform.LookAt(player);
	}
}
