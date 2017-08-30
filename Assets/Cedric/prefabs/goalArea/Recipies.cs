using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipies : MonoBehaviour {
    public List<GameObject> list;
    public float price;


    public bool check (List<GameObject> received)
    {
        HashSet<GameObject> h = new HashSet<GameObject>(list);
        return h.SetEquals(received);
    }

    public float getPrice()
    {
        return price;
    }
}
