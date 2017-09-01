using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public int playerNumber;
    private Rigidbody c_rig;
    private Vector3 inputVector;
    private Vector3 lastRotation;
    bool walking = false;
	private bool isInteracting = false;

	int deathTimer = 0;
	int deathDelay = 100;

    private float movementSpeed = 7.0f;
    private Animator animator;

	public Transform respawnLocation;

	//death booleans
	bool dead = false;
	private Vector3 lastDeathLocation;
	bool lockDeathLocation = false;
	public bool isDead()
	{
		return dead;
	}
	public Vector3 getLastDeathLocation()
	{
		return lastDeathLocation;
	}

	void Start () 
	{
        c_rig = transform.GetComponent<Rigidbody>();
        animator = this.GetComponentInChildren<Animator>();
	}
    void Update() 
	{
        walking = this.inputVector == Vector3.zero ? false : true;
        animator.SetBool("isWalking", walking);
        if (!dead && !isInteracting) 
		{
            movement();
        }
		if (dead) 
		{
			deathTimer++;
			if (deathTimer % deathDelay == 0) 
			{
				deathTimer = 0;
				dead = false;
				respawn ();
			}
		}
		testIfDead ();
    }

	void respawn()
	{
		c_rig.velocity = new Vector3 (0.0f, 0.0f, 0.0f);
		c_rig.MovePosition(respawnLocation.position);
		lockDeathLocation = true;
	}
	void testIfDead()
	{
		Collider[] coll = Physics.OverlapSphere (this.transform.position, 0.2f);
		for (int i = 0; i < coll.Length; i++)
		{
			if (coll[i].transform.gameObject.layer == 4)
			{
				dead = true;
				if (lockDeathLocation == false) 
			{
					lastDeathLocation = this.transform.position;
				}
			}
		}
	}
   
	void movement()
	{
        if (playerNumber == 1) {
            inputVector = new Vector3(Input.GetAxis("P1Horizontal"), 0.0f, Input.GetAxis("P1Vertical"));
        }
        else if (playerNumber == 2)
		{
            inputVector = new Vector3(Input.GetAxis("P2Horizontal"), 0.0f, Input.GetAxis("P2Vertical"));
        }
		Vector3 moveVector3 = new Vector3 (0.0f, 0.0f, 0.0f);
		//Moving Platform fix - If the controller isn't used, the player will follow along a moving platform
		if (inputVector != Vector3.zero) 
		{
			moveVector3 = inputVector * movementSpeed;
			moveVector3.y = c_rig.velocity.y;
			c_rig.velocity = moveVector3;
		}
        if (inputVector != Vector3.zero) 
		{
            lastRotation = new Vector3(this.transform.position.x + moveVector3.x, this.transform.position.y, this.transform.position.z + moveVector3.z);
        }
        lastRotation.y = this.transform.position.y;
        this.transform.LookAt(lastRotation);
    }

    public void setDead(bool _b) 
	{
        dead = _b;
    }
	public void setIsInteracting(bool value)
	{
		isInteracting = value;
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
