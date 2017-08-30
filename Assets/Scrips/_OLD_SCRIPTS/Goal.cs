using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    Transform gameManager;
    MoneyCounter mc;
    void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<Transform>();
        mc = gameManager.GetComponentInChildren<MoneyCounter>();
     //   mc.setMoney(mc.getMoney() + 10);
    }
    public void checkFood(Food f) {
        //tests de validité de la bouffe
        if (f.cooked == true) {
            if (f.burnt == true) {
                mc.setMoney(mc.getMoney() - 5);
            }
            else {
                mc.setMoney(mc.getMoney() + 10);
            }
        }
        else {
            mc.setMoney(mc.getMoney() - 10);
        }
        Destroy(f.gameObject);
    }
}
