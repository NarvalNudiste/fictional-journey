using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public Transform[] player;
    public Transform centerOfScene;
    private float lerpSpeed = 0.5f;
    public bool centerOnPlayer = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (centerOnPlayer) {
            transform.LookAt(player[0]);
        }
        else {
            Vector3 target;
            if (player.Length == 0) {
                target = Vector3.Lerp(centerOfScene.position, (player[0].transform.position), lerpSpeed);
            }
            else {
                Vector3 averagePos = new Vector3(0.0f, 0.0f, 0.0f);
                for (int i = 0; i < player.Length; i++) {
                    averagePos += player[i].position;
                }
                averagePos /= player.Length;
                target = Vector3.Lerp(centerOfScene.position, averagePos, lerpSpeed);
            }
            transform.LookAt(target);
        }

	}
}
