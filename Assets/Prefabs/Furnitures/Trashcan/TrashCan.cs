using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : abstractFurniture {

	override public bool setItem(GameObject item, GameObject player)
    {
        if (item.GetComponent<plate>()!= null)
        {
            item.GetComponent<plate>().destroyList();
        }
        Destroy(item);
        return true;
    }
    override public GameObject getItem(){ return null; }
    override protected bool canProcess(AbstractFood food) { return true; }
    override protected void process(bool value) { }
    override protected void updateFurniture() { }
    override protected void loadBarUpdate() { }
}

