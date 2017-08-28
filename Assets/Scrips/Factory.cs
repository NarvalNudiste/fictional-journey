using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour {
    private Animator animator;
    private Light light;
    private ParticleSystem ps;
    public Transform itemPoint;
    public Transform loadBar;
    
    
    private enum states {
        CLOSED,
        OPEN
    }
    public Transform currentItemIn;
    private states currentState;

    void Start() {
        light = GetComponentInChildren<Light>();
        light.intensity = 0.0f;
        animator = GetComponent<Animator>();
        currentState = states.OPEN;
        animator.SetBool("open", true);
        ps = GetComponentInChildren<ParticleSystem>();
    }

    public bool setItem(Transform _item) {
        if (currentItemIn != null) {
            return false;
        }
        else {
            this.currentItemIn = _item;
            currentState = states.CLOSED;
            this.currentItemIn.GetComponent<Food>().setCooking(true);
            return true;
        }
    }

    public Transform getItem() {
        if (currentItemIn == null) {
            return null;
        }
        else {
            currentItemIn.GetComponent<Rigidbody>().WakeUp();
            this.currentItemIn.GetComponent<Food>().setCooking(false);
            Transform temp = currentItemIn;
            currentState = states.OPEN;
            currentItemIn = null;
            return temp;
        }
    }
    void Update() {
            if (currentState == states.OPEN) {
                animator.SetBool("open", false);
                ps.enableEmission = false;
            loadBar.gameObject.SetActive(false);
            light.intensity = 0.0f;
            loadBar.transform.GetComponent<LookAtCamera>().setLoading(0.0f);
        }
            else {
            animator.SetBool("open", true);
            ps.enableEmission = true;
            light.intensity = 1.0f;
            loadBar.gameObject.SetActive(true);
            loadBar.transform.GetComponent<LookAtCamera>().setLoading((float)currentItemIn.GetComponent<Food>().timeSpentCooking / (float)currentItemIn.GetComponent<Food>().timeToCook);
        }

            if (currentItemIn != null) {
            // Rigidbody temp = currentItemIn.GetComponent<Rigidbody>();
            currentItemIn.GetComponent<Rigidbody>().detectCollisions = false;
            currentItemIn.transform.position = this.itemPoint.transform.position;
            currentItemIn.GetComponent<Rigidbody>().Sleep();
        }
    }
}
