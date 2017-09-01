using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class abstractFurniture : MonoBehaviour 
{
	protected enum State 
	{
		CLOSED,
		OPEN
	}
	public Transform itemPos = null;
	public LookAtCamera loadBar = null;
	public Transform throwPoint = null;
	public float throwVel = 10;
	protected AbstractFood content = null;
	protected GameObject contentParent = null;
	protected State state = State.OPEN;
	protected GameObject lastPlayerInteracting = null;
	protected bool firstCycle = false;

	abstract protected bool canProcess (AbstractFood food); // Check if we can cook/slice/spice.
	abstract protected void process (bool value);			// Set isCooking/isSlicing/isSpicing.
	abstract protected void updateFurniture(); 				// Update animation & particules.
	abstract protected void loadBarUpdate();

	virtual public bool setItem(GameObject item, GameObject player)
	{
		if (content == null) 
		{
			lastPlayerInteracting = player;
			contentParent = item;
			content =  item.GetComponent<AbstractFood>();
			if (content != null && canProcess (content)) {
				state = State.CLOSED;
				loadBar.gameObject.SetActive (true);
				Rigidbody rb = contentParent.GetComponent<Rigidbody> ();
				rb.rotation = GetComponent<Rigidbody> ().rotation;
				rb.Sleep ();
				contentParent.transform.position = itemPos.position;
				updateFurniture();
				process (true);
				return true;
			} 
			else 
			{
				content = null;
				contentParent = null;
			}
		}
		return false;
	}
	virtual public GameObject getItem() 
	{
		if (content != null) 
		{
			process (false);
			state = State.OPEN;
			loadBar.gameObject.SetActive (false);
			contentParent.GetComponent<Rigidbody> ().WakeUp ();
			content = null;
			updateFurniture();
			return contentParent;
		} else
			return null;

	}
	void OnCollisionEnter(Collision col)
	{
		if (setItem (col.gameObject, null))
			col.gameObject.GetComponent<Rigidbody> ().detectCollisions = false;
	}
	virtual public void ejectItem()
	{
		if (throwPoint != null) 
		{	
			GameObject toThrow = getItem ();
			toThrow.GetComponent<Rigidbody> ().detectCollisions = true;
			toThrow.transform.position = throwPoint.position;
			Vector3 throwVec = throwPoint.position - transform.position + new Vector3 (0, transform.position.y, 0);
			toThrow.GetComponent<Rigidbody> ().velocity = (throwVec.normalized + new Vector3 (0, 1, 0)).normalized * throwVel;
		}
	}
	public void setIsInteracting(bool value)
	{
		PlayerMovement darum = lastPlayerInteracting.GetComponent<PlayerMovement>();
		if (darum != null)
			darum.setIsInteracting (value);
	}

	void Update()
	{
		if (content != null) 
		{
			contentParent.transform.position = itemPos.position;
			loadBarUpdate ();
			if (!canProcess (content)) 
			{
				process (false);
				loadBar.gameObject.SetActive (false);
				updateFurniture();
			}
			if (loadBar.getLoading () == 1f)
				firstCycle = true;
			if (throwPoint != null && firstCycle && loadBar.getLoading () == 0.05f) 
			{
				ejectItem ();
				firstCycle = false;
			}
		}
	}
}

