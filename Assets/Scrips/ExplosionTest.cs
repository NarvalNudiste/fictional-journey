using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.S)) {
            Collider[] colls = Physics.OverlapSphere(this.transform.position, 1000f);
            for (int i = 0; i<colls.Length; i++) {
                Rigidbody temp = colls[i].GetComponent<Rigidbody>();
                if (temp != null) {
                    if (temp.GetComponent<Transform>().tag == "player") {
                        temp.GetComponent<PlayerMovement>().setDead(true);
                    }
                    temp.AddExplosionForce(100000f, this.transform.position, 100f);
                }
            }
        }
	}
}
