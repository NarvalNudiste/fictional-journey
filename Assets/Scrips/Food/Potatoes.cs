using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Potatoes : AbstractFood {
	public GameObject rawModel = null;
	public GameObject slicedModel = null;
	public GameObject puree = null;
	public GameObject cookedModel = null;
	public GameObject fire = null;

	private AudioSource source = null;

	void Awake () {
		foodName = "Potatoes";
		slicingTime = 200;
		cookingTime = 600;
		price = 10f;

		if (slicedModel != null) {
			slicedModel.SetActive (false);
		}
		if (rawModel != null) {
			rawModel.SetActive (true);
		}
		if (puree != null) {
			puree.SetActive (false);
		}
		if (cookedModel != null) {
			cookedModel.SetActive (false);
		}
		canSlice = true;
		canDeliver = true;
		canCook = false;

		source = GetComponent<AudioSource> ();
	}
	override protected void updateFood () {
		if (sliceState == Slicing.SLICED && cookState < Cooking.COOKED) {
			canCook = true;
			rawModel.SetActive (false);
			slicedModel.SetActive (true);
			cookedModel.SetActive (false);
			puree.SetActive (false);
			price += 0.30f;
			slicingTime = slicingTime * 0.5f;
		}
		if (sliceState == Slicing.MIXED) {
			rawModel.SetActive (false);
			slicedModel.SetActive (false);
			cookedModel.SetActive (false);
			puree.SetActive (true);
			canCook = false;
			price += 1.0f;
		}
		if (cookState == Cooking.COOKED) {
			canSlice = false;
			rawModel.SetActive (false);
			slicedModel.SetActive (false);
			cookedModel.SetActive (true);
			price += 1.0f;
			cookingTime = cookingTime * 0.5f;
		}
		if (cookState == Cooking.BURNED) {
			if (source != null && fire != null) 
			{
				fire.SetActive (true);
				source.Play ();
			}
			price = 0f;
		}
	}
}
