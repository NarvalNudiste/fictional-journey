using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class used to grab world objects and keep references of it, as well as basic interaction with factories
 */
public class PlayerGrab : MonoBehaviour {
    private Rigidbody c_rig;
    public Transform heldPoint;
    public Transform grabHitBox;
    private Transform heldObject;
    float grabRadius = 1.0f;
    public bool isHoldingSomething = false;
    private bool checkNeeded = false;
    int playerNumber;

    void Start () {
        playerNumber = this.GetComponent<PlayerMovement>().playerNumber;
        c_rig = transform.GetComponent<Rigidbody>();
    }
	void Update () {
        grab();
	}
    void grab() {
        bool grabButton = false;
        if (playerNumber == 1) {
            grabButton = Input.GetButtonDown("P1Fire1");
        }
        else if (playerNumber == 2) {
            grabButton = Input.GetButtonDown("P2Fire1");
        }   
            if (grabButton) {
                Collider[] coll = Physics.OverlapSphere(grabHitBox.position, grabRadius);
                if (isHoldingSomething) {
                    //check if a machine is in there, breaks if finds one
                    if (coll != null) {
                        for (int i = 0; i < coll.Length; i++) {
                            if (coll[i].GetComponent<Transform>().tag == "machine") {
                                coll[i].GetComponent<Factory>().setItem(this.heldObject);
                                heldObject.GetComponent<Rigidbody>().detectCollisions = true;
                                heldObject = null;
                                isHoldingSomething = false;
                                checkNeeded = false;
                                break;
                            }
                            else {
                                checkNeeded = true;
                            }
                        }
                    }
                    //collisions not null, but no machine in there -> drop item
                    if (checkNeeded == true) {
                        Debug.Log("should drop it, item : " + heldObject);
                        heldObject.GetComponent<Rigidbody>().detectCollisions = true;
                        heldObject = null;
                        isHoldingSomething = false;
                    }
                }
                else {
                    //if not holding something, we check if something is in range
                    if (coll != null) {
                        for (int i = 0; i < coll.Length; i++) {
                            if (coll[i].GetComponent<Transform>().tag == "grabbable") {
                                //grab the item
                                heldObject = coll[i].GetComponent<Transform>();
                                isHoldingSomething = true;
                                break;
                            }
                            else if (coll[i].GetComponent<Transform>().tag == "machine") {
                                heldObject = coll[i].GetComponent<Factory>().getItem();
                                if (heldObject != null) {
                                    isHoldingSomething = true;
                                }
                                break;
                            }
                        }
                    }
                }
            }

            if (heldObject != null) {
                heldObject.GetComponent<Rigidbody>().detectCollisions = false;
                heldObject.transform.position = heldPoint.position;
                heldObject.GetComponent<Rigidbody>().velocity = c_rig.velocity;
            }
    }
}
