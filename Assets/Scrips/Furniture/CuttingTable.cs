using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingTable : abstractFurniture {

	void Start() 
	{
		//animator = GetComponent<Animator>();
		//updateFurniture ();
	}

	protected override void updateFurniture()
	{
		if (state == State.OPEN) {
			//animator.SetBool("open", false); 
			setIsInteracting(false);
		} else {
			//animator.SetBool("open", true);
			setIsInteracting(true);
			Vector3 lookPoint = new Vector3 
			(
				transform.position.x, 
				lastPlayerInteracting.transform.position.y, 
				transform.position.z
			);
			lastPlayerInteracting.transform.LookAt(lookPoint);
		}
	}
	protected override bool canProcess (AbstractFood food)
	{
		if (content.getSlicePerm ()) {
			return true;
		} else
			return false;
	}
	protected override void process (bool value)
	{
		content.setSlicing (value);
	}
	protected override void loadBarUpdate()
	{
		if (content.getSliceState () < Slicing.MIXED) 
		{
			float value = content.getTimeSpentSlicing () / (content.GetSlicingTime () + 0.01f);
			value = value - value % 0.05f + 0.05f;
			loadBar.setLoading (value);
			if (value == 0.05f) 
			{
				switch (content.getSliceState ()) {
				case Slicing.NONE:
					loadBar.setColor (Color.green);
					break;
				case Slicing.SLICED:
					loadBar.setColor (Color.yellow);
					break;
				}
			}
		} else
			loadBar.gameObject.SetActive (false);
	}
}
