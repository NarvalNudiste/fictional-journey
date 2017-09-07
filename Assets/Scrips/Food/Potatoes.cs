using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Potatoes : AbstractFood {
	public GameObject rawModel = null;
	public GameObject slicedModel = null;
	public GameObject cookedModel = null;
	void Awake () {
		foodName = "Potatoes";
		slicingTime = 200;
		cookingTime = 1200;
		price = 2f;

		if (slicedModel != null) {
			slicedModel.SetActive (false);
		}
		if (rawModel != null) {
			rawModel.SetActive (true);
		}
		if (cookedModel != null) {
			cookedModel.SetActive (false);
		}
		canSlice = true;
		canDeliver = true;
		canCook = false;
	}
	override protected void updateFood () {
		if (sliceState == Slicing.SLICED) {
			canCook = true;
			rawModel.SetActive (false);
			slicedModel.SetActive (true);
			cookedModel.SetActive (false);
			price += 0.30f;
			slicingTime = slicingTime * 0.5f;
		}
		if (cookState == Cooking.COOKED) {
			rawModel.SetActive (false);
			slicedModel.SetActive (false);
			cookedModel.SetActive (true);
			price += 1.0f;
			cookingTime = cookingTime * 0.5f;
		}
	}
}
