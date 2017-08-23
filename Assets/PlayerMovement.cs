using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public int playerNumber;
    private Rigidbody c_rig;
    private Vector3 inputVector;
    private Vector3 lastRotation;
    bool dead = false;

    private float movementSpeed = 7.0f;

	void Start () {
        c_rig = transform.GetComponent<Rigidbody>();
	}
    void Update() {
        if (!dead) {
            movement();
        }

    }
        void movement(){
        if (playerNumber == 1) {
            inputVector = new Vector3(Input.GetAxis("P1Horizontal"), 0.0f, Input.GetAxis("P1Vertical"));
        }
        else if (playerNumber == 2){
                inputVector = new Vector3(Input.GetAxis("P2Horizontal"), 0.0f, Input.GetAxis("P2Vertical"));
            }

        Vector3 moveVector3 = inputVector * movementSpeed;
        moveVector3.y = c_rig.velocity.y;
        c_rig.velocity = moveVector3;

        if (inputVector != Vector3.zero) {
            lastRotation = new Vector3(this.transform.position.x + moveVector3.x, this.transform.position.y, this.transform.position.z + moveVector3.z);
        }
        lastRotation.y = this.transform.position.y;
        this.transform.LookAt(lastRotation);
    }

    public void setDead(bool _b) {
        dead = _b;
    }
}


//Quaternion variant, should be better but broken
/* Quaternion rotation = Quaternion.LookRotation(moveVector3);
 if (inputVector == Vector3.zero) {
     c_rig.rotation = lastRotation;
 }
 else {
     c_rig.rotation = rotation;
     lastRotation = rotation;
 } */
