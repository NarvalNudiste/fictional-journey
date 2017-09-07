using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Transform gameOverScreen;
	public Transform mayhemPoint;
    public void timerEnded() {
        GetComponentInChildren<FinishScreen>(true).gameObject.SetActive(true);
        GetComponentInChildren<FinishScreen>(true).show(GetComponent<MoneyCounter>().getMoney());
        mayhemPoint.GetComponent<EXPLOSIONLOL> ().explode ();
    }
}
