using System.Collections;
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

	Stopwatch stopwatch = new Stopwatch(); 
	float holdDelay = 200f;
	bool holdCheck = false;
	bool holdFurniture = false;
	bool interact = false;

	const float dropStrenghtFront = 200;
	const float dropStrenghtUp = 400;

	void Start () {
		playerNumber = this.GetComponent<PlayerMovement>().playerNumber;
		rigidBody = this.GetComponent<Rigidbody>();
		animator = this.GetComponentInChildren<Animator>();
	}
	void Update () {
		holdOrClick ();
		if (interact) 
		{
			interact = false;
			if (heldObject == null)
				grab ();
			else
				drop ();

		}
		// Hold object in front of player.
		if (heldObject != null) {
			if (holdFurniture) 
			{
				
			} 
			else 
			{
				heldObject.transform.position = heldPoint.position;
				heldObject.GetComponent<Rigidbody> ().velocity = rigidBody.velocity;
			}
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
				if (objit.tag == "grabbable" && !holdFurniture) // Grab item
				{ 
					heldObject = objit;
					heldObject.GetComponent<Rigidbody> ().detectCollisions = false;
					break;
				} 
				else if (objit.tag == "machine" && !holdFurniture) // Take content
				{ 
					heldObject = coll [i].GetComponent<abstractFurniture> ().getItem ();
					break;
				} 
				else if ( objit.tag == "movable" && holdFurniture) 
				{
					heldObject = objit;
					Rigidbody objRb = heldObject.GetComponent<Rigidbody> ();
					if(objRb != null)
						objRb.detectCollisions = false;
					foreach (Rigidbody ribi in heldObject.GetComponentsInChildren<Rigidbody>())
						ribi.detectCollisions = false;
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
				if (objit.tag == "machine" && !holdFurniture)	// Put food in furniture.
				{
					if (coll [i].GetComponent<abstractFurniture> ().setItem (heldObject, gameObject)) 
					{
						heldObject = null;
					}
					return;
				}
				else if(objit.tag == "movable" && holdFurniture) // Drop furniture
				{
					Rigidbody objRb = heldObject.GetComponent<Rigidbody> ();
					if(objRb != null)
						objRb.detectCollisions = true;
					foreach (Rigidbody ribi in heldObject.GetComponentsInChildren<Rigidbody>())
						ribi.detectCollisions = true;
					break;
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

			heldObject = null;
		}
	}
	private void holdOrClick()
	{
		if (Input.GetButtonDown ("P" + playerNumber + "Fire1"))
		{
			stopwatch.Start ();
			holdCheck = true;
			holdFurniture = false; //reset after use
		}
		if(Input.GetButtonUp ("P" + playerNumber + "Fire1"))
		{
			stopwatch.Stop ();
			stopwatch.Reset ();
			holdCheck = false;
			interact = true;
		}
		if(holdCheck)
		{
			if (stopwatch.ElapsedMilliseconds >= holdDelay) 
			{
				stopwatch.Stop ();
				stopwatch.Reset ();
				holdCheck = false;
				interact = true;
				holdFurniture = true;
			}
		}
	}
}

