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

	protected const float timeMultiplier = 1; // Delete this
	protected float cookingTime = 200;
	protected float slicingTime = 200;
	protected float spicingTime = 200;

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

	abstract protected void updateFood ();
	void Update() // USE DELTA TIME
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
	public float GetCookingTime(){
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

	//Time spent processing
	public float getTimeSpentCooking(){
		return timeSpentCooking;
	}
	public float getTimeSpentSlicing(){
		return timeSpentSlicing;
	}
	public float getTimeSpentSpicing(){
		return timeSpentSpicing;
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
	public Cooking getCookingLvl(){
		return cooking;
	}
	public Slicing getSlicingLvl(){
		return slicing;
	}
	public Spicing getSpicingLvl(){
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

	public void setCooking(bool value){
		if (canCook && value)
			isCooking = true;
		else
			isCooking = false;
	}
	public void setSlicing(bool value){
		if (canSlice && value)
			isSlicing = true;
		else
			isSlicing = false;
	}
		public void setSpicing(bool value){
		if (canSpice && value)
			isSpicing = true;
		else
			isSpicing = false;
	}

    public float getPrice()
    {
        return price;
    }
}
