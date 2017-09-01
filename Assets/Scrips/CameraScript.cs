using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public Transform[] player;
    public Transform centerOfScene;
    private float lerpSpeed = 0.5f;
    public bool centerOnPlayer;

	void Update () {
		//todo fix camera
        if (centerOnPlayer) {
            transform.LookAt(player[0]);
        }
        else {
            Vector3 target;
			if (player.Length == 1) {
				Transform playerT = player [0].GetComponent<Transform> ();

				if (playerT.GetComponent<PlayerMovement> ().isDead ()) {
					target = Vector3.Lerp (playerT.GetComponent<PlayerMovement>().getLastDeathLocation(), centerOfScene.position, lerpSpeed);
				} else {
					target = Vector3.Lerp(centerOfScene.position, playerT.transform.position, lerpSpeed);
				}

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
