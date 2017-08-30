using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour 
{
	public Camera currentCamera;
	private Loader loader;

	void Start () {
		loader = GetComponentInChildren<Loader> ();
	}
	void Update () {
		transform.LookAt (currentCamera.transform);
	}

	public void setLoading(float value)
	{
        if (loader != null)
		loader.setLoading (value);
	}
	public float getLoading()
	{   if (loader != null)
            return loader.getLoading();
        else return 0.0f;
	}

	public void setColor(Color color)
	{
		loader.setColor (color);
	}
	public Color getColor()
	{
		return loader.getColor ();
	}
}
