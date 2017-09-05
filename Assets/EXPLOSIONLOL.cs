using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPLOSIONLOL : MonoBehaviour {
	public void explode(){
		Collider[] c = Physics.OverlapSphere (this.transform.position, 1000000f);
		for (int i = 0; i < c.Length; i++) {
			Rigidbody[] temp = c [i].GetComponentsInChildren<Rigidbody> ();
			for (int j = 0; j < temp.Length; j++){
				if (temp[j] != null) {
					temp[j].isKinematic = false;
					temp[j].AddExplosionForce (10000f, this.transform.position, 1000000f);
				}
			}
		} 
	}
}
