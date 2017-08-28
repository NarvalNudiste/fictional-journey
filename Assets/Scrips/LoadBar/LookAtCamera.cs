using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour 
{
	public Camera currentCamera;
	private Loader loader;

	// Use this for initialization
	void Start () {
		//transform = GetComponent<Transform> ();
		loader = GetComponentInChildren<Loader> ();
	}
	
	// Update is called once per frame
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
}
