using UnityEngine;
using System.Collections;

//This script allows a sound to be played regardless if the player inspects this or not.

public class ApproachSoundEvent : MonoBehaviour {

	public AudioClip soundBite;		//What audio will play here?
	public float soundVolume;		//How loud is the sound playing?

	//The player will activate a sound bit if they are near this.
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			if(GameObject.Find("SoundPlayer").GetComponent<AudioSource>().isPlaying == false)
				GameObject.Find("SoundPlayer").GetComponent<AudioSource>().PlayOneShot(soundBite,1f);
		}
	}
}
