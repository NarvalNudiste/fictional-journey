using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Transform gameOverScreen;
	public Transform mayhemPoint;
    public bool shouldRespawn;

    void Start()
    {
        shouldRespawn = true;
    }

    public void timerEnded() {
        shouldRespawn = false;
        PlayerMovement[] players = GameObject.FindObjectsOfType<PlayerMovement>();
        foreach (PlayerMovement item in players)
        {
            item.setDead(true);
        }
        GetComponentInChildren<FinishScreen>(true).gameObject.SetActive(true);
        GetComponentInChildren<FinishScreen>(true).show(GetComponent<MoneyCounter>().getMoney());
        mayhemPoint.GetComponent<EXPLOSIONLOL> ().explode ();
    }
}
