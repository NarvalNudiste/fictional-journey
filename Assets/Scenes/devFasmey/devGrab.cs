using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class devGrab : MonoBehaviour {
	public Transform heldPoint;
	public Transform grabHitBox;
	private Rigidbody rigidBody;
	private GameObject heldObject;
	float grabRadius = 1.0f;
	int playerNumber = 1;
	string playerName;

	void Start () {
		playerNumber = this.GetComponent<PlayerMovement>().playerNumber;
		rigidBody = this.GetComponent<Rigidbody>();
	}
	void Update () {
		// Interaction.
		if (Input.GetButtonDown("P"+playerNumber+"Fire1")) 
		{
			if (heldObject == null) //Empty hands -> grab something
			{
				grab ();
			}
			else // Filled hands -> drop it
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

	void grab()
	{
		Collider[] coll = Physics.OverlapSphere(grabHitBox.position, grabRadius);
		if (coll != null)
		{
			for (int i = 0; i < coll.Length; i++) 
			{
				GameObject objit = coll [i].GetComponent<GameObject> ();
				if (objit.tag == "grabbable") // Grab item
				{
					heldObject = objit;
					heldObject.GetComponent<Rigidbody>().detectCollisions = false;
					break;
				}
				else if (objit.tag == "machine") // Take content
				{
					heldObject = coll[i].GetComponent<abstractFurniture>().getItem();
					// Collision false by default.
					break;
				}
			}
		}
	}
	void drop()
	{
		Collider[] coll = Physics.OverlapSphere(grabHitBox.position, grabRadius);
		if (coll != null) 
		{
			for (int i = 0; i < coll.Length; i++) 
			{
				GameObject objit = coll [i].GetComponent<GameObject> ();
				if (objit.tag == "machine") 
				{
					// Collision false by default.
					coll[i].GetComponent<abstractFurniture>().setItem(heldObject);
					heldObject = null;
					break;
				}
			}
			//if nothing to put it in, just drop it!
			heldObject = null;
		}
	}
}

