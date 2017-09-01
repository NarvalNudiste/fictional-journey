using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicingTable : abstractFurniture {


	protected override void process(bool value){
		content.setSlicing (value);
	}

	protected override bool canProcess (AbstractFood food){
		if (content.getSlicePerm ()) {
			return true;
		} else {
			return false;
		}
	}

	protected override void loadBarUpdate(){
	}

	protected override void updateFurniture(){
	}
}
