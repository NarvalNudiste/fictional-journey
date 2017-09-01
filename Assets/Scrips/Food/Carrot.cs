using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : AbstractFood {

	public GameObject rawCarrot = null;
	public GameObject slicedCarrot = null;
	public GameObject squashedCarrot = null;

	void Awake()
	{
		foodName = "Carrot";
		slicingTime = 300;
		price = 0.10f; // base price of the raw carrot

		rawCarrot.SetActive(true);
		slicedCarrot.SetActive (false);
		squashedCarrot.SetActive (false);

		canSlice = true;
		canDeliver = true;
	}
	override protected void updateFood ()
	{
		if (sliceState == Slicing.SLICED) {
			rawCarrot.SetActive (false);
			slicedCarrot.SetActive (true);
			price += 0.10f;
			slicingTime = slicingTime * 0.5f;
		} else if (sliceState == Slicing.MIXED) {
			slicedCarrot.SetActive (false);
			squashedCarrot.SetActive (true);
			canSlice = false;
			price += 0.80f;
		}
	}
}
