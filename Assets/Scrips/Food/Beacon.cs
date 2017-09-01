using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : AbstractFood{

	public GameObject rawBeacon = null;
	public GameObject cookedBeacon = null;
	public GameObject burnedBeacon = null;

	void Awake()
	{
		foodName = "Beacon";
		color = Color.red;
		cookingTime = 500;
		price = 0.10f;

		rawBeacon.SetActive (true);
		cookedBeacon.SetActive (false);
		burnedBeacon.SetActive (false);

		canCook = true;
		canDeliver = true;
	}
	override protected void updateFood ()
	{
		if (cookState == Cooking.COOKED) {
			rawBeacon.SetActive (false);
			cookedBeacon.SetActive (true);
			price += 0.90f;
			cookingTime = cookingTime * 0.15f;
		} else if (cookState == Cooking.BURNED) {
			cookedBeacon.SetActive (false);
			burnedBeacon.SetActive (true);
			canCook = false;
			price = 0f;
		}
	}
}
