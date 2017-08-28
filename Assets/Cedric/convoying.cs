using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class convoying : MonoBehaviour {

    public string direction;
    public string axis;
    public float strenght;

	// Use this for initialization
	void Start () {
        //axis = "X";
        //direction = "F";
        //strenght = 3;
	}
	
    void OnCollisionStay(Collision col)
    {
        Rigidbody rb =col.gameObject.GetComponent<Rigidbody>();

        Vector3 v = new Vector3();

        switch (axis)
        {
            case "X":
                v.x = strenght;
                break;
            case "Z":
                v.z = strenght;
                break;
            default:
                break;
        }

        switch (direction)
        {
            case "B":
                v *= -1;
                break;
            default:
                break;
        }

        rb.velocity = v;
        //Debug.Log(rb.name);

    }

	// Update is called once per frame
	void Update () {

	}
}
