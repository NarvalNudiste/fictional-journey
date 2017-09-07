using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyCounter : MonoBehaviour {
    private Text moneyText;
    float currentMoney = 0;
    void Start() {
        moneyText = GameObject.Find("MoneyText").GetComponent<Text>();
    }
    void Update() {
        moneyText.text = "moni : " + currentMoney + " $$$";
    }
    public void setMoney(float _m) {
        currentMoney = _m;
    }
    public float getMoney() {
        return currentMoney;
    }
}
