using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class devGrab : MonoBehaviour {
	public Transform heldPoint;
	public Transform grabHitBox;
	private Rigidbody rigidBody;
	private GameObject heldObject;
	float grabRadius = 2.0f;
	int playerNumber = 1;
	string playerName;

	const float dropStrenghtFront = 200;
	const float dropStrenghtUp = 400;

	void Start () {
		playerNumber = this.GetComponent<PlayerMovement>().playerNumber;
		rigidBody = this.GetComponent<Rigidbody>();
	}
	void Update () {
		if (Input.GetButtonDown("P"+playerNumber+"Fire1")) 
		{
			if (heldObject == null)
			{
				grab ();
			}
			else
			{
				drop ();
			}
		}
		// Hold object in front of player.
		if (heldObject != null) 
		{
			heldObject.transform.position = heldPoint.position;
			heldObject.GetComponent<Rigidbody>().velocity = rigidBody.velocity;
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
					heldObject.GetComponent<Rigidbody>().detectCollisions = false;
					break;
				}
				else if (objit.tag == "machine") // Take content
				{
					heldObject = coll[i].GetComponent<abstractFurniture>().getItem();
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
				if (objit.tag == "machine") //Put in furnace.
				{
					if (coll [i].GetComponent<abstractFurniture> ().setItem (heldObject)) 
					{
						heldObject = null;
					}
					return;
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
}

