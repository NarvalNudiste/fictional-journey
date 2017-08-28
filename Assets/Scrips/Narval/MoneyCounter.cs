using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyCounter : MonoBehaviour {
    private Text moneyText;
    int currentMoney = 10;
    void Start() {
        moneyText = GameObject.Find("MoneyText").GetComponent<Text>();
    }
    void Update() {
        moneyText.text = "moni : " + currentMoney + " $$$";
    }
    public void setMoney(int _m) {
        currentMoney = _m;
    }
    public int getMoney() {
        return currentMoney;
    }
}
