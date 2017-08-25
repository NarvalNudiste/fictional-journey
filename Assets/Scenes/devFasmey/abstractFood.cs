using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class AbstractFood : MonoBehaviour 
{
	protected string foodName = "Food";
	protected Color color = Color.red;
	protected float price = 0.10f; //default raw price

	protected bool isCooking = false;
	protected bool isSlicing = false;
	protected bool isSpicing = false;

	protected const float timeMultiplier = 60; //60FPS -> 10 * 60 = 10s
	protected float cookingTime = 10;
	protected float slicingTime = 10;
	protected float spicingTime = 10;

	protected float timeSpentCooking = 0;
	protected float timeSpentSlicing = 0;
	protected float timeSpentSpicing = 0;

	protected Cooking cooking = Cooking.RAW;
	protected Slicing slicing = Slicing.NONE;
	protected Spicing spicing = Spicing.NONE;

	protected bool canCook = false;
	protected bool canSlice = false;
	protected bool canSpice = false;
	protected bool canDeliver = true;

	void Update()
	{
		if (isCooking) 
		{
			timeSpentCooking++;
			if (timeSpentCooking >= cookingTime * timeMultiplier) 
			{
				timeSpentCooking = 0;
				cook ();
			}
		}
		else if (isSlicing) 
		{
			timeSpentSlicing++;
			if (timeSpentSlicing >= slicingTime * timeMultiplier) 
			{
				timeSpentSlicing = 0;
				slice ();
			}
		}
		else if (isSpicing) 
		{
			timeSpentSpicing++;
			if (timeSpentSpicing >= spicingTime * timeMultiplier) 
			{
				timeSpentSpicing = 0;
				spice ();
			}
		}
	}
	abstract protected void updateFood ();

	// Basic
	public string getFoodname(){
		return foodName;
	}
	public void setFoodName(string value){
		foodName = value;
	}

	public Color getColor(){
		return color;
	}
	public void setColor(Color value){
		color = value;
	}

	// Time to process
	public float GetCookingTime(int value){
		return cookingTime;
	}
	protected  void SetCookingTime(float value){
		cookingTime = value;
	}

	public float GetSlicingTime(){
		return slicingTime;
	}
	protected void SetSlicingTime(float value){
		slicingTime = value;
	}
	public float GetSpicingTime(){
		return spicingTime;
	}
	protected void SetSpicingTime(float value){
		spicingTime = value;
	}

	// Food's State
	protected void cook()
	{
		if (cooking != Cooking.BURNNING) {
			cooking++;
			updateFood ();
		}
	}
	protected void slice()
	{
		if (slicing != Slicing.MIXED) {
			slicing++;
			updateFood ();
		}
	}
	protected void spice()
	{
		if (spicing != Spicing.LETHAL) {
			spicing++;
			updateFood ();
		}
	}
	public Cooking getCooking(){
		return cooking;
	}
	public Slicing getSlicing(){
		return slicing;
	}
	public Spicing getSpicing(){
		return spicing;
	}

	// Permissions { get }
	public bool getCookPerm(){
		return canCook;
	}
	public bool getSlicePerm(){
		return canSlice;
	}
	public bool getSpcicePerm(){
		return canSpice;
	}
}
