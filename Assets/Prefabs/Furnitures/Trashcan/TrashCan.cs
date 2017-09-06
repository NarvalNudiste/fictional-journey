using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : abstractFurniture 
{
	public AudioClip dropSound = null;
	private AudioSource source = null;

	void Start()
	{
		source = GetComponent<AudioSource> ();
	}
	override public bool setItem(GameObject item, GameObject player)
    {
        if(item.tag == "grabbable")
        {
            if (item.GetComponent<plate>() != null)
            {
                item.GetComponent<plate>().destroyList();
            }
            Destroy(item);
			if (source != null && dropSound != null) {
				source.PlayOneShot (dropSound, 0.5f);
			}
            return true;
        }
        return false;
    }
    override public GameObject getItem(){ return null; }
    override protected bool canProcess(AbstractFood food) { return true; }
    override protected void process(bool value) { }
    override protected void updateFurniture() { }
    override protected void loadBarUpdate() { }
}

