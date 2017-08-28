using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Furnace : abstractFurniture 
{
	protected override void updateFurniture()
	{
		if (state == State.OPEN) {
			//Animation OPEN
			//Particle off
		} else 
		{
			//Animation CLOSE
			//Particle on... whatever...
		}
	}

	protected override bool canProcess (AbstractFood food)
	{
		if (content.getCookPerm ()) {
			return true;
		} else
			return false;
	}
	protected override void process (bool value)
	{
		content.setCooking (true);
	}
}
