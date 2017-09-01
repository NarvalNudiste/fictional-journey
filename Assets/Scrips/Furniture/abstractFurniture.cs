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
	protected AbstractFood content = null;
	protected GameObject contentParent = null;
	protected State state = State.OPEN;
	protected GameObject lastPlayerInteracting = null;

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
		}
	}
}

