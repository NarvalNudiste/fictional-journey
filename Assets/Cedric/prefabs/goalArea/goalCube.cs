using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalCube : MonoBehaviour {

    Transform gameManager;
    MoneyCounter mc;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<Transform>();
        mc = gameManager.GetComponentInChildren<MoneyCounter>();
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
            foreach (Transform item in list)
            {
                checkFood(item.gameObject.GetComponent<AbstractFood>());
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
