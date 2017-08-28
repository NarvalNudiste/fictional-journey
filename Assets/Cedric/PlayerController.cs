using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    //movement variables
    public float hAxis, vAxis;
    private float hSpeed, vSpeed;
    public float speed = 0.0f;
    private float acceleration = 0.2f;
    private float brakeForce = 0.5f;
    private Vector3 currentVelocity;
    public Vector3 targetVelocity;
    private Rigidbody c_rig;
    public Transform model;

    //grabbing stuff
    public Transform heldPoint;
    public Transform grabHitBox;
    private Transform heldObject;
    float grabRadius = 1.0f;
    public bool isHoldingSomething = false;
    private bool checkNeeded = false;

    private float maxSpeed = 6.0f;
    // Use this for initialization
    void Start()
    {
        hSpeed = vSpeed = 0.0f;
        c_rig = this.transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        currentVelocity = c_rig.velocity;
        movement();
        grab();
    }

    void grab()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Collider[] coll = Physics.OverlapSphere(grabHitBox.position, grabRadius);
            if (isHoldingSomething)
            {
                //check if a plate is in there, breaks if finds one
                if (coll != null)
                {
                    for (int i = 0; i < coll.Length; i++)
                    {
                        if (coll[i].GetComponent<Transform>().tag == "plate" && heldObject.tag != "plate")
                        {
                            coll[i].GetComponent<plate>().stackItem(this.heldObject);
                            heldObject.GetComponent<Rigidbody>().detectCollisions = true;
                            heldObject = null;
                            isHoldingSomething = false;
                            checkNeeded = false;
                            break;
                        }
                        else
                        {
                            checkNeeded = true;
                        }
                    }
                }
                //collisions not null, but no plate in there -> drop item
                if (checkNeeded == true)
                {
                    Debug.Log("should drop it, item : " + heldObject);
                    heldObject.GetComponent<Rigidbody>().detectCollisions = true;
                    heldObject = null;
                    isHoldingSomething = false;
                }
            }
            else
            {
                //if not holding something, we check if something is in range
                if (coll != null)
                {
                    for (int i = 0; i < coll.Length; i++)
                    {
                        if (coll[i].GetComponent<Transform>().tag == "grabbable" || coll[i].GetComponent<Transform>().tag == "plate")
                        {
                            //grab the item
                            heldObject = coll[i].GetComponent<Transform>();
                            isHoldingSomething = true;
                            break;
                        }
                    }
                }
            }
        }

        if (heldObject != null)
        {
            heldObject.GetComponent<Rigidbody>().detectCollisions = false;
            heldObject.transform.position = heldPoint.position;
            heldObject.GetComponent<Rigidbody>().velocity = c_rig.velocity;
        }
    }

    void movement()
    {


        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 1.5f * maxSpeed;
        }

        targetVelocity = Vector3.Normalize(new Vector3(hAxis, 0.0f, vAxis));
        if ((hAxis != 0 || vAxis != 0) && Mathf.Abs(speed) < maxSpeed)
        {
            speed += acceleration;
        }
        else
        {
            if (speed > 0.0f)
            {
                speed -= brakeForce;
            }
            if (Mathf.Abs(speed) < 0.1 || speed < 0.0f)
            {
                speed = 0;
            }
        }

        //todo fix rotation
        if ((targetVelocity.x != 0.0f || targetVelocity.z != 0.0f) || (targetVelocity.x != 0.0f && targetVelocity.z != 0.0f))
        {
            transform.rotation = Quaternion.LookRotation(targetVelocity);
        }

        c_rig.velocity = new Vector3(targetVelocity.x * speed, c_rig.velocity.y, targetVelocity.z * speed);
    }
}