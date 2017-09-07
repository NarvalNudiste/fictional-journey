using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class AutoFurnace : abstractFurniture 
{
	public ParticleSystem smoke = null;

	public AudioClip inAndOut = null;
	private AudioSource source = null;

	void Start() 
	{
		source = GetComponent<AudioSource> ();
		updateFurniture ();
	}

	protected override void updateFurniture()
	{
		if (state == State.OPEN) {
			smoke.enableEmission = false;
			if (source != null && inAndOut != null) 
			{
				source.Stop ();
				source.PlayOneShot (inAndOut);
			}
		} else {
			smoke.enableEmission = true;
			if (source != null && source.clip != null && inAndOut != null) 
			{
				source.PlayOneShot (inAndOut);
				source.Play();
			}
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
				switch (content.getCookState ()) {
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
