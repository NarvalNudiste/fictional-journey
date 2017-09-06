using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteakDisp : MonoBehaviour {

    public GameObject dispObj;
    public float timer;
    float time;
    Vector3 pos;

    // Use this for initialization
    void Start () {
        time = Time.time;
        pos = this.transform.position;
        pos.y -= 1;
    }
	
	// Update is called once per frame
	void Update () {
		if(Time.time-time >=timer)
        {
            GameObject temp = GameObject.Instantiate(dispObj);
            temp.transform.position = pos;
            time = Time.time;
        }
	}
}
