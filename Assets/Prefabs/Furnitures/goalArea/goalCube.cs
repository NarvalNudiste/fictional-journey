using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalCube : MonoBehaviour {

    Transform gameManager;
    MoneyCounter mc;
    private AbstractFood[] recipie;
    float recipiePrice;

	public AudioClip win = null;
	public AudioClip fail = null;
	private AudioSource source = null;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<Transform>();
        mc = gameManager.GetComponentInChildren<MoneyCounter>();
        recipie = this.GetComponentsInChildren<AbstractFood>(true);
		source = GetComponent<AudioSource> ();
    }
	
	// Update is called once per frame
	void Update () {
        int cpt = 0;
        foreach (AbstractFood item in recipie)
        {
            item.gameObject.GetComponent<Rigidbody>().detectCollisions = false;
            item.gameObject.SetActive(true);
            Vector3 pos = this.transform.position;
            pos.y += 2+cpt* item.transform.localScale.y;
            item.transform.position = pos;
            cpt++;
        }
	}

    void OnCollisionEnter(Collision col)
    {
        //test si assiète complète sinon pas acceptée
        if (col.gameObject.GetComponent<plate>() != null)
        {
            recipiePrice = 0;
            List<Transform> list = col.gameObject.GetComponent<plate>().getList();

            bool result = true;

            for (int i = 0; i < recipie.Length; i++)
            {
                //Debug.Log("recipie :" + recipie[i].name + "// plate :" + list[i].GetComponent<AbstractFood>().name);
                if(recipie[i].cookState != list[i].GetComponent<AbstractFood>().cookState ||
                   recipie[i].sliceState != list[i].GetComponent<AbstractFood>().sliceState ||
                   recipie[i].name.Equals(list[i].GetComponent<AbstractFood>().name))
                {
                    recipiePrice -= list[i].GetComponent<AbstractFood>().getPrice();
                }
                else
                {
                    recipiePrice += list[i].GetComponent<AbstractFood>().getPrice();
                }
            }

			if(source != null && win != null)
				source.PlayOneShot (win);
            mc.setMoney(mc.getMoney() + recipiePrice);


            col.gameObject.GetComponent<plate>().destroyList();
            Destroy(col.gameObject);
        }
    }
}
