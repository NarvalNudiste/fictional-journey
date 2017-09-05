using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Transform gameOverScreen;
	public Transform mayhemPoint;
    public void timerEnded() {
		mayhemPoint.GetComponent<EXPLOSIONLOL> ().explode ();
    }
}
