using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loader : MonoBehaviour 
{

	private RectTransform loadBar;
	private Image img;
	private float loading = 0; // [0,1]

	void Start () 
	{
		img = GetComponent<Image> ();
		loadBar = GetComponent<RectTransform> ();
	}

	public void setLoading (float value)
	{
		if (value > 1)
			loading = 1;
		else if (value < 0)
			loading = 0;
		else
			loading = value;
		loaderUpdate (loading);
	}
	public float getLoading ()
	{
		return loading;
	}

	public void setColor(Color color)
	{
		img.color = color;
	}
	public Color getColor()
	{
		return img.color;
	}

	private void loaderUpdate (float value)
	{
		Vector3 temp = loadBar.localScale;
		temp.x = value;
		loadBar.localScale = temp;
	}
}
