using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

	public List<GameObject> plates = new List<GameObject>();
	public Transform startPoint;
	public Transform endPoint;
	public float speed = 0.02f;
	public float pusherstrength = 2f;
	private Vector3 conveyVec;
	private Pusher pusher;

	public AudioClip throwSound = null;
	private AudioSource source = null;

	void Awake()
	{
		conveyVec = endPoint.position - startPoint.position;
		int nbPlates = plates.Capacity;
		Vector3 diffPos = conveyVec / nbPlates;
		for (int i=0; i<nbPlates; i++) 
		{
			plates[i].GetComponent<Pusher> ().setStrength (pusherstrength);
			plates [i].transform.position = startPoint.position + diffPos*i;
		}
		//speedVector
		conveyVec = conveyVec.normalized * speed;

		source = GetComponent<AudioSource> ();
	}
	void Update () {
		conveyVec = (endPoint.position - startPoint.position).normalized*speed;
		foreach (GameObject plate in plates) 
		{
			plate.transform.Translate (conveyVec, Space.World);
			pusher = plate.GetComponent<Pusher> ();
			pusher.setPushVec (conveyVec - new Vector3(0, conveyVec.y,0));
			if (plate.transform.localPosition.y >= endPoint.localPosition.y) //teleport back to end pos
			{
				pusher.push ();
				if (source != null && throwSound != null)
					source.PlayOneShot (throwSound);
				plate.transform.position = startPoint.position;
			}
		}
	}
}
