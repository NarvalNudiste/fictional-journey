using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Furnace : abstractFurniture 
{
	public ParticleSystem smoke = null;
	public Light furnaceLight = null;
	public Animator animator;

	void Start() 
	{
		animator = GetComponent<Animator>();
		updateFurniture ();
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
		float value = content.getTimeSpentCooking () / (content.GetCookingTime() + 0.01f);
		value = value - value % 0.05f + 0.05f;
		loadBar.setLoading (value);
	}
}
