using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Steak : AbstractFood {

	public GameObject rawSteak = null;
	public GameObject cookedSteak = null;
	public GameObject burnedSteak = null;
	public GameObject fire = null;

	void Awake()
	{
		foodName = "Steak";
		cookingTime = 600;
		price = 0.10f; // base price of the raw steak

		rawSteak.SetActive (true);
		cookedSteak.SetActive (false);
		burnedSteak.SetActive (false);

		canCook = true;
		canDeliver = true;

	}
	override protected void updateFood ()
	{
		if (cookState == Cooking.COOKED) {
			rawSteak.SetActive (false);
			cookedSteak.SetActive (true);
			price += 0.90f;
			cookingTime = cookingTime * 0.5f;
		} else if (cookState == Cooking.BURNED) {
			cookedSteak.SetActive (false);
			burnedSteak.SetActive (true);
			price = 0f;
		} else if (cookState == Cooking.BURNNING) {
			fire.SetActive(true);
		}
	}
}