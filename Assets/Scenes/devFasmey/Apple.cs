using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*	apple recipe example:
 * 		slice
 * 		cook
 * 		deliver
 * */
class Apple: AbstractFood
{
	public GameObject rawApple = null;
	public GameObject slicedApple = null;
	public GameObject cookedSlicedApple = null;
	public GameObject squashedApple = null;
	public GameObject burnedSlicedApple = null;

	void Start()
	{
		foodName = "Apple";
		color = Color.red;
		cookingTime = 10;
		slicingTime = 5;
		price = 0.10f; // base price of the raw apple

		rawApple.SetActive (true); // display rawApple model
		slicedApple.SetActive (false);
		cookedSlicedApple.SetActive (false);
		squashedApple.SetActive (false);
		burnedSlicedApple.SetActive (false);

		canCook = false;
		canSlice = true;
		canSpice = false;
		canDeliver = true;

	}
	override protected void updateFood ()
	{
		if (slicing == Slicing.SLICED) {
			rawApple.SetActive (false);
			slicedApple.SetActive (true);
			canCook = true;
			price += 0.10f;
			slicingTime = slicingTime * 0.5f;
		} else if (cooking == Cooking.COOKED) {
			slicedApple.SetActive (false);
			cookedSlicedApple.SetActive (true);
			canSlice = false;
			price += 0.80f;
			cookingTime = cookingTime * 0.33f;
		} else if (slicing == Slicing.MIXED) {
			slicedApple.SetActive (false);
			squashedApple.SetActive (true);
			canSlice = false;
			price = 0f;
		} else if (cooking == Cooking.BURNED) {
			cookedSlicedApple.SetActive (false);
			burnedSlicedApple.SetActive (true);
			canCook = false;
			price = 0f;
		}
	}
}