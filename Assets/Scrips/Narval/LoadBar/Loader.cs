using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour 
{

	private RectTransform loadBar;
	private float loading = 0; // [0,1]

	void Start () 
	{
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

	private void loaderUpdate (float value)
	{
		Vector3 temp = loadBar.localScale;
		temp.x = value;
		loadBar.localScale = temp;
	}
}
