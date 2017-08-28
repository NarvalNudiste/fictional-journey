using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevate : MonoBehaviour {
    private Rigidbody plateform;
    private float startY;
    private float endY;
    bool ascending;
    public float velocity;
    public bool doPush;
    public float PushStrenght;
    public string axis;
    public string direction;

	// Use this for initialization
	void Start () {
        plateform = this.GetComponentInChildren<Rigidbody>();
        startY = plateform.position.y;
        endY = startY+this.transform.localScale.y;
        ascending = true;
	}

    void Update()
    {
        if (ascending)
        {
            if (plateform.position.y>=endY)
            {
                if (doPush)
                {
                    this.GetComponentInChildren<pusher>().push(PushStrenght,axis,direction);
                }
                ascending = false;
            }
            else
            {
                plateform.velocity = new Vector3(0, velocity, 0);
            }
        }
        else
        {
            plateform.velocity = new Vector3(0, -velocity, 0);
            if (plateform.position.y <= startY)
            {
                ascending = true;
            }
        }
    }
}
