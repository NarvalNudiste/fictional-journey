﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class devGrab : MonoBehaviour {
	public Transform heldPoint;
	public Transform grabHitBox;
	private Rigidbody rigidBody;
	private GameObject heldObject;
	private Animator animator;
	float grabRadius = 1.5f;
	int playerNumber = 1;
	string playerName;

	const float dropStrenghtFront = 200;
	const float dropStrenghtUp = 400;

	public AudioClip dropSound = null;
	private AudioSource source = null;

	void Start () {
		playerNumber = this.GetComponent<PlayerMovement>().playerNumber;
		rigidBody = this.GetComponent<Rigidbody>();
		animator = this.GetComponentInChildren<Animator>();
		source = GetComponent<AudioSource> ();
	}
	void Update () {
		if (Input.GetButtonDown ("P" + playerNumber + "Fire1")) 
		{
			if (heldObject == null)
				grab ();
			else
				drop ();

		}
		// Hold object in front of player.
		if (heldObject != null) {
			heldObject.transform.position = heldPoint.position;
			heldObject.GetComponent<Rigidbody> ().velocity = rigidBody.velocity;
			animator.SetBool ("isHoldingSomething", true);
		}
		else {
			animator.SetBool ("isHoldingSomething", false);
		}
	}

	private void grab()
	{
		Collider[] coll = Physics.OverlapSphere(grabHitBox.position, grabRadius);
		if (coll != null)
		{
			for (int i = 0; i < coll.Length; i++) 
			{
				GameObject objit = coll [i].gameObject;
				if (objit.tag == "grabbable") // Grab item
				{ 
					heldObject = objit;
					heldObject.GetComponent<Rigidbody> ().detectCollisions = false;
					break;
				} 
				else if (objit.tag == "machine") // Take content
				{ 
					heldObject = coll [i].GetComponent<abstractFurniture> ().getItem ();
					break;
				} 
			}
		}
	}
	private void drop()
	{
		Collider[] coll = Physics.OverlapSphere(grabHitBox.position, grabRadius);
		if (coll != null) 
		{
			for (int i = 0; i < coll.Length; i++) 
			{
				GameObject objit = coll [i].gameObject;
				if (objit.tag == "machine")	// Put food in furniture.
				{
					if (coll [i].GetComponent<abstractFurniture> ().setItem (heldObject, gameObject)) 
					{
						heldObject = null;
					}
					return;
				}
                else if(objit.GetComponent<plate>()!=null) // Put on plate
                {
                    objit.GetComponent<plate>().stackItem(heldObject.transform);
                }
			}
			Rigidbody heldRb = heldObject.GetComponent<Rigidbody> ();
			heldRb.detectCollisions = true;

			Rigidbody rb = GetComponent<Rigidbody> ();
			Vector3 characterFront = (heldRb.position - rb.position).normalized * dropStrenghtFront;
			characterFront.y = dropStrenghtUp;
			heldRb.AddForce (characterFront);
			heldRb.detectCollisions = true;
			heldObject = null;

			source.PlayOneShot (dropSound, 1f);
		}
	}
}

