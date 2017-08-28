using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
    public bool cooked = false;
    public bool burnt = false;
    public bool isBeingCooked = false;
    public int timeToCook;
    public int counter = 0;
    public int timeSpentCooking = 0;

    public void setTimeToCook(int _time) {
        this.timeToCook = _time;
    }

    public void setCooking(bool _b) {
        this.isBeingCooked = _b;
    }
	// Update is called once per frame
	void Update () {
        checkCuisson();
    }
    protected void checkCuisson() {
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
            //Renderer rend = this.GetComponent<Renderer>();
            //rend.material.shader = Shader.Find("Specular");
            //rend.material.SetColor("_SpecColor", Color.red);
        }
        if (timeSpentCooking == (int)2 * timeToCook) {
            Debug.Log("overcooked lol");
            burnt = true;
            //Renderer rend = this.GetComponent<Renderer>();
            //rend.material.shader = Shader.Find("Specular");
            //rend.material.SetColor("_SpecColor", Color.black);
        }
    }
}
