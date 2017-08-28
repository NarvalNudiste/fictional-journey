using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSteak : Food {
    public Transform rawModel;
    public Transform cookedModel;
    public Transform burntModel;
	// Use this for initialization
	void Start () {
        rawModel.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        checkCuisson();
        if (cooked) {
            rawModel.gameObject.SetActive(false);
            cookedModel.gameObject.SetActive(true);
        }
        if (burnt) {
            cookedModel.gameObject.SetActive(false);
            burntModel.gameObject.SetActive(true);
        }
	}
}
