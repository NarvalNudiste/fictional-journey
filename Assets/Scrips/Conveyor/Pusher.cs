using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher: MonoBehaviour
{
	private List<Rigidbody> plates = null;
	private Vector3 pushVec;
	private float strength = 1f;

	void Awake()
	{
		pushVec = new Vector3 (strength, 0, 0);
	}
	public void push (){
		foreach (Rigidbody plate in plates) 
		{
			plate.AddForce (pushVec);
		}
	}
	void OnCollisionEnter(Collision col)
	{
		Rigidbody body = col.gameObject.GetComponent<Rigidbody> ();
		if(body!=null)
			plates.Add (body);
	}
	void OnCollisionExit(Collision col)
	{
		Rigidbody body = col.gameObject.GetComponent<Rigidbody> ();
		if (body != null)
			plates.Remove (body);
	}
	public void setStrength(float powaaaa)
	{
		strength = powaaaa;
	}
	public void setPushVec(Vector3 vector)
	{
		pushVec = vector.normalized * strength;
	}
}


