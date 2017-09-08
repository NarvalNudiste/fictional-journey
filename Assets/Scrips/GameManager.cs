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
		this.gameObject.AddComponent<MusicSingleton> ();
        shouldRespawn = true;
    }

	void Update(){
		/*if (Input.GetKey(KeyCode.F1)){
			Application.LoadLevel("level1");
		}
		if (Input.GetKey(KeyCode.F2)){
				Application.LoadLevel("level2");
		}
        if (Input.GetKey(KeyCode.F3))
        {
            Application.LoadLevel("level1_multi");
        }
        if (Input.GetKey(KeyCode.F4))
        {
            Application.LoadLevel("level2_multi");
        }
        if (Input.GetKey(KeyCode.F5))
        {
            Application.LoadLevel("menu");
        }*/
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
