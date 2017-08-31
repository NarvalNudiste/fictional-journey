using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

	public List<GameObject> plates;
	public float speed = 0.02f;
	public float endPos = 1.5f;
	public float startPos = -1.5f;
	public Vector3 startPoint;
	public Vector3 endPoint;
	private Vector3 conveyVec;
	private Pusher pusher;

	void Awake()
	{
		conveyVec = new Vector3 (0, speed, 0);
		startPoint = new Vector3 (0, startPos, 0);
		endPoint = new Vector3 (0, endPos, 0);
	}
	void Update () {
		foreach (GameObject plate in plates) 
		{
			plate.transform.Translate (conveyVec);
			if (plate.transform.localPosition.y >= endPos) //teleport back to end pos
			{
				//pusher = plate.GetComponent<Pusher> ();
				//pusher.push ();
				plate.transform.position -= endPoint - startPoint;
			}
		}
	}
}
