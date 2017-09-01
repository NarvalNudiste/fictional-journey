using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : AbstractFood {

	public GameObject rawEgg = null;
	public GameObject openEgg= null; //sliced
	public GameObject squashedEgg = null;
	public GameObject friedEgg = null;
	public GameObject burnedEgg = null;

	void Awake()
	{
		foodName = "Egg";
		color = Color.white;
		cookingTime = 300;
		slicingTime = 200;
		price = 0.10f; // base price of the raw apple

		rawEgg.SetActive (true);
		openEgg.SetActive(false);
		squashedEgg.SetActive (false);
		friedEgg.SetActive(false);
		burnedEgg.SetActive(false);
	}
	override protected void updateFood ()
	{
		if (sliceState == Slicing.SLICED) {
			rawEgg.SetActive (false);
			openEgg.SetActive (true);
			canCook = true;
			price += 0.10f;
			slicingTime = slicingTime * 0.5f;
		} else if (cookState == Cooking.COOKED) {
			openEgg.SetActive (false);
			friedEgg.SetActive (true);
			canSlice = false;
			price += 0.80f;
			cookingTime = cookingTime * 0.33f;
		} else if (sliceState == Slicing.MIXED) {
			openEgg.SetActive (false);
			squashedEgg.SetActive (true);
			canSlice = false;
			canCook = false;
			price = 0f;
		} else if (cookState == Cooking.BURNED) {
			friedEgg.SetActive (false);
			burnedEgg.SetActive (true);
			canCook = false;
			price = 0f;
		}
	}
}
