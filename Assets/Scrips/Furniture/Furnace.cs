using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Furnace : abstractFurniture 
{
	public ParticleSystem smoke = null;
	public Light furnaceLight = null;
	public Animator animator = null;

	public AudioClip ovenDoor = null;

	private AudioSource source;

	void Start() 
	{
		animator = GetComponent<Animator>();
		updateFurniture ();
		source = GetComponent<AudioSource> ();
	}

	protected override void updateFurniture()
	{
		if (state == State.OPEN) {
			furnaceLight.intensity = 0f;
			animator.SetBool("open", false); // Not obvious... >_>
			smoke.enableEmission = false;
		} else {
			furnaceLight.intensity = 1f;
			animator.SetBool("open", true);
			smoke.enableEmission = true;
			if (source != null && ovenDoor != null)
				source.PlayOneShot (ovenDoor);
			else
				print ("null");
		}
	}
	protected override bool canProcess (AbstractFood food)
	{
		if (content.getCookPerm ()) {
			return true;
		} else
			return false;
	}
	protected override void process (bool value)
	{
		content.setCooking (value);
	}
	protected override void loadBarUpdate()
	{
		if (content.getCookState () < Cooking.BURNNING) 
		{
			float value = content.getTimeSpentCooking () / (content.GetCookingTime () + 0.01f);
			value = value - value % 0.05f + 0.05f;
			loadBar.setLoading (value);
			if (value == 0.05f) 
			{
				switch (content.getCookState ()) 
				{
				case Cooking.RAW:
					loadBar.setColor (Color.green);
					break;
				case Cooking.COOKED:
					loadBar.setColor (Color.yellow);
					break;
				case Cooking.BURNED:
					loadBar.setColor (Color.red);
					break;
				}
			}
		} else
			loadBar.gameObject.SetActive (false);
	}
}
