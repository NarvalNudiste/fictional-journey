﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : AbstractFood {

	public GameObject rawBread = null;
	void Awake()
	{
		foodName = "Breade";
		price = 0.10f;
		rawBread.SetActive (true);
		canDeliver = true;
	}
	override protected void updateFood ()
	{
	}
}