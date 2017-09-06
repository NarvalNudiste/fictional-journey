using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher: MonoBehaviour
{
	private List<Rigidbody> onPlate = null;
	private Vector3 pushVec;
	private float strength = 1f;
	private Rigidbody thisRb;

	public AudioClip throwSound = null;
	private AudioSource source = null;

	void Awake()
	{
		pushVec = new Vector3 (1, 1, 0).normalized;
		onPlate = new List<Rigidbody> ();
		thisRb = GetComponent<Rigidbody> ();

		source = GetComponent<AudioSource> ();
	}
	public void push ()
	{
		if(onPlate.Count > 0 && source != null && throwSound != null)
			source.PlayOneShot (throwSound);
		foreach (Rigidbody objit in onPlate)
			objit.velocity = pushVec*strength;
	}
	void OnCollisionEnter(Collision col)
	{
		Rigidbody body = col.gameObject.GetComponent<Rigidbody> ();
		if(body!=null)
			onPlate.Add (body);
	}
	void OnCollisionExit(Collision col)
	{
		Rigidbody body = col.gameObject.GetComponent<Rigidbody> ();
		if (body != null)
			onPlate.Remove (body);
	}
	public void setStrength(float powaaaa)
	{
		strength = powaaaa;
	}
	public void setPushVec(Vector3 vector)
	{
		pushVec = vector.normalized;
		pushVec.y = 1;
	}
}


