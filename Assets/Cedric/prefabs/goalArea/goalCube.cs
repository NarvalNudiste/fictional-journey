using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalCube : MonoBehaviour {

    Transform gameManager;
    MoneyCounter mc;
    private AbstractFood[] recipie;
    public float recipiePrice;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<Transform>();
        mc = gameManager.GetComponentInChildren<MoneyCounter>();
        recipie = this.GetComponentsInChildren<AbstractFood>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        //test si assiète complète sinon pas accepté
        if (col.gameObject.GetComponent<plate>() != null && col.gameObject.GetComponent<plate>().isComplete())
        {
            List<Transform> list = col.gameObject.GetComponent<plate>().getList();
            /*foreach (Transform item in list)
            {
                checkFood(item.gameObject.GetComponent<AbstractFood>());
            }*/

            bool result = true;

            for (int i = 0; i < recipie.Length; i++)
            {
                if(recipie[i].cooking != list[i].GetComponent<AbstractFood>().cooking)
                {
                    result = false;
                }
            }

            if (result)
            {
                mc.setMoney(mc.getMoney() + recipiePrice);
            }

            col.gameObject.GetComponent<plate>().destroyList();
            Destroy(col.gameObject);
        }
    }

    void checkFood(AbstractFood f)
    {
        mc.setMoney(mc.getMoney() + f.getPrice());
    }
}
