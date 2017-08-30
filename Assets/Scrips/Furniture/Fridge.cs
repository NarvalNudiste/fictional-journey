using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Fridge : abstractFurniture 
{
	override public bool setItem(GameObject item){ return false; }
	override public GameObject getItem()
	{
		GameObject temp = GameObject.Instantiate (itemPos).gameObject;
		temp.SetActive (true);
		temp.GetComponent<Rigidbody> ().detectCollisions=false;
		return temp;
	}
	override protected bool canProcess (AbstractFood food){ return true; }
	override protected void process (bool value){}
	override protected void updateFurniture(){}
	override protected void loadBarUpdate(){}
}
