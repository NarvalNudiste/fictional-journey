using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour {
	public float strength = 1.5f;
	private Vector3 convey;
	
	// Update is called once per frame
	void OnCollisionStay(Collision col)
	{
		Rigidbody[] rb = col.gameObject.GetComponents<Rigidbody>();
		convey = transform.TransformDirection (new Vector3 (1, 0, 0));
		convey *= strength;
		foreach(Rigidbody rbibi in rb)
		{
			float mag = rbibi.velocity.magnitude;
			rbibi.velocity = (convey + rbibi.velocity).normalized * strength;
		}
	}
}
