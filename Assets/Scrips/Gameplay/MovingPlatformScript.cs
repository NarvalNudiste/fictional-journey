using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour {
	public int delay;
	public float speed;
	public Vector3 target;
	private Vector3 startPosition;
	private bool returnNeeded = false;
	private enum state {
		WAITING = 0,
		GOING = 1,
		RETURNING = 2
	}
	private int timer = 0;
	state currentState;
	// Use this for initialization
	void Start () {
		startPosition = this.transform.position;
		currentState = state.GOING;
	}

	void Update () {
		if (currentState == state.GOING) {
			this.GetComponent<Rigidbody>().MovePosition(Vector3.Lerp(startPosition, target, timer * 1.0f/(float)delay));
		} else if (currentState == state.RETURNING) {
					this.GetComponent<Rigidbody>().MovePosition(Vector3.Lerp (target, startPosition, timer * 1.0f/(float)delay));
		} else {
			//waiting
		}
		timer++;
		if (timer % delay == 0) {
			if (currentState == state.GOING || currentState == state.RETURNING) {
				if (currentState == state.GOING) {
					returnNeeded = true;
				}
				if (currentState == state.RETURNING) {
					returnNeeded = false;
				}
				currentState = state.WAITING;
			}
			else {
				if (returnNeeded) {
					currentState = state.RETURNING;
				} 
				else {
					currentState = state.GOING;
				}
			}
			timer = 0;
		}
	}
}
