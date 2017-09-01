using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plate : MonoBehaviour {

    private List<Transform> stack;
    private Rigidbody c_rig;

    // Use this for initialization
    void Start () {
        stack = new List<Transform>();
        c_rig = this.transform.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        int cpt = 1;
        foreach (Transform item in stack)
        {
            item.GetComponent<Rigidbody>().detectCollisions = false;
            item.GetComponent<Rigidbody>().rotation = c_rig.rotation;
            Vector3 v = c_rig.position;
            v.y += cpt*0.2f;
            item.GetComponent<Rigidbody>().position = v;
            item.GetComponent<Rigidbody>().velocity = c_rig.velocity;
            item.GetComponent<Rigidbody>().useGravity = false;
            cpt++;
        }
	}

    public void stackItem(Transform obj)
    {
        
        if(obj.GetComponent<plate>()==null)
        {
            stack.Add(obj);
        }
    }

    public int numberOfToppings() { return stack.Count; }

    public List<Transform> getList() { return stack; }

    public void destroyList()
    {
        foreach (Transform item in stack)
        {
            Destroy(item.gameObject);
        }
    }

}
