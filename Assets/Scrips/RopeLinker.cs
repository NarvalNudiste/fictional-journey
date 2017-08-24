using UnityEngine;

public class RopeLinker : MonoBehaviour 
{
	void Start () 
	{
		GetComponent<CharacterJoint> ().connectedBody = transform.parent.GetComponent<Rigidbody> ();
	}
}
