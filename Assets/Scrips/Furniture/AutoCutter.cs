using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCutter : abstractFurniture
{
	public AudioClip outJumpSound = null;
	public AudioClip inOutSound = null;
	private AudioSource source = null;
	void Start() 
	{
		updateFurniture ();
		source = GetComponent<AudioSource> ();
	}

	protected override void updateFurniture()
	{
		if (state == State.OPEN) {
			if (source != null && inOutSound != null && outJumpSound != null) 
			{
				source.Stop ();
				source.PlayOneShot (inOutSound);
				source.PlayOneShot (outJumpSound);
			}
		} else {
			if (source != null && source.clip != null && inOutSound != null) 
			{
				source.PlayOneShot (inOutSound);
				source.Play();
			}
		}
	}
	protected override bool canProcess (AbstractFood food)
	{
		if (content.getSlicePerm()) {
			return true;
		} else
			return false;
	}
	protected override void process (bool value)
	{
		content.setSlicing (value);
	}
	protected override void loadBarUpdate()
	{
		if (content.getSliceState() < Slicing.MIXED) 
		{
			float value = content.getTimeSpentSlicing() / (content.GetSlicingTime () + 0.01f);
			value = value - value % 0.05f + 0.05f;
			loadBar.setLoading (value);
			if (value == 0.05f) 
			{
				switch (content.getSliceState ()) {
				case Slicing.NONE:
					loadBar.setColor (Color.green);
					break;
				case Slicing.SLICED:
					loadBar.setColor (Color.yellow);
					break;
				}
			}
		} else
			loadBar.gameObject.SetActive (false);
	}
}
