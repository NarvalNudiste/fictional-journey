using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
    private bool cooked = false;
    private bool burnt = false;
    private bool isBeingCooked = false;
    public int timeToCook;
    int counter = 0;
    int timeSpentCooking = 0;

    public void setTimeToCook(int _time) {
        this.timeToCook = _time;
    }

    public void setCooking(bool _b) {
        this.isBeingCooked = _b;
    }
	// Update is called once per frame
	void Update () {
        if (isBeingCooked) {
            counter++;
            if (counter % 60 == 0) {
                timeSpentCooking++;
                counter = 0;
            }
        }
        if (timeSpentCooking == timeToCook) {
            Debug.Log("cooked");
            cooked = true;
            this.GetComponent<Renderer>().material.color = Color.red;
            //Renderer rend = this.GetComponent<Renderer>();
            //rend.material.shader = Shader.Find("Specular");
            //rend.material.SetColor("_SpecColor", Color.red);
        }
        if (timeSpentCooking == (int)2 * timeToCook) {
            Debug.Log("overcooked lol");
            burnt = true;
            this.GetComponent<Renderer>().material.color = Color.black;
            //Renderer rend = this.GetComponent<Renderer>();
            //rend.material.shader = Shader.Find("Specular");
            //rend.material.SetColor("_SpecColor", Color.black);
        }
    }
}
