using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plate : MonoBehaviour {

    private List<Transform> stack;
    private Rigidbody c_rig;
    private bool complete { get; set; }
    private int ToppingMax;

    // Use this for initialization
    void Start () {
        stack = new List<Transform>();
        c_rig = this.transform.GetComponent<Rigidbody>();
        complete = false;
        ToppingMax = 2;
    }
	
	// Update is called once per frame
	void Update () {
        int cpt = 1;
        foreach (Transform item in stack)
        {
            item.GetComponent<Rigidbody>().detectCollisions = false;
            Vector3 v = c_rig.position;
            v.y += cpt*item.localScale.y;
            item.GetComponent<Rigidbody>().position = v;
            item.GetComponent<Rigidbody>().velocity = c_rig.velocity;
            item.GetComponent<Rigidbody>().useGravity = false;
            cpt++;
        }
	}

    public void stackItem(Transform obj)
    {
        
        if(stack.Count<ToppingMax && obj.GetComponent<plate>()==null)
        {
            stack.Add(obj);
        }

        if (stack.Count == ToppingMax)
        {
            complete = true;
        }
    }

    public bool isComplete() { return complete; }

    public List<Transform> getList() { return stack; }

    public void destroyList()
    {
        foreach (Transform item in stack)
        {
            Destroy(item.gameObject);
        }
    }

}
