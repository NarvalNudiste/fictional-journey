using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class abstractFurniture : MonoBehaviour 
{
	protected enum State 
	{
		CLOSED,
		OPEN
	}
	protected AbstractFood content = null;
	protected GameObject contentParent = null;
	protected State state = State.OPEN;

	abstract protected bool canProcess (AbstractFood food); // Check if we can cook/slice/spice.
	abstract protected void process (bool value);			// Set isCooking/isSlicing/isSpicing.
	abstract protected void updateFurniture(); 				// Update animation & particules.
	public bool setItem(GameObject item)
	{
		if (content == null) 
		{
			contentParent = item; // To avoid GetComponent access..
			content =  item.GetComponent<AbstractFood>();
			if (canProcess (content)) {
				state = State.CLOSED;
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
	public GameObject getItem() 
	{
		if (content != null) 
		{
			state = State.OPEN;
			contentParent.SetActive (true);
			content = null;
			process (false);
			updateFurniture();
			return contentParent;
		} else
			return null;

	}

	void Update()
	{
		if (content != null && !canProcess (content)) 
		{
			process (false);
			updateFurniture();
		}
	}
}

