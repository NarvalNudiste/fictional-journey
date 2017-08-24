using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour 
{
	public Camera currentCamera;
	private Transform transform;
	private Loader loader;

	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform> ();
		loader = GetComponentInChildren<Loader> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (currentCamera.transform);
	}

	void setLoading(float value)
	{
		loader.setLoading (value);
	}

	float getLoading()
	{
		return loader.getLoading ();
	}
}
