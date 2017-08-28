using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pusher : MonoBehaviour {
    List<Rigidbody> l;

	// Use this for initialization
	void Start () {
        l = new List<Rigidbody>();
	}


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name != "Elevator")
        {
            //Debug.Log("add" + col.gameObject.name);
            if(col.gameObject.GetComponent<Rigidbody>()!=null)
            {
                l.Add(col.gameObject.GetComponent<Rigidbody>());
            }
            
        }
        
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name != "Elevator")
        {
            //Debug.Log("remove" + col.gameObject.name);
            if (col.gameObject.GetComponent<Rigidbody>() != null)
            {
                l.Remove(col.gameObject.GetComponent<Rigidbody>());
            }
        }
    }

    public void push(float strenght,string axis,string direction)
    {
        Vector3 v=Vector3.zero;
        switch (axis)
        {
            case "X":
                v = Vector3.right;
                break;
            case "Z":
                v = Vector3.forward;
                break;
            default:
                break;
        }

        if (direction == "B")
        {
            v *= -1;
        }

        foreach (Rigidbody item in l)
        {
            Debug.Log("push "+item.name);
            item.velocity = v * strenght;
        }
    }
}
