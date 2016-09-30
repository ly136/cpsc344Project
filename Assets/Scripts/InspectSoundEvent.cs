using UnityEngine;
using System.Collections;

//This simply plays a sound clip if the player inspects it.

public class InspectSoundEvent : MonoBehaviour {

	public AudioClip soundBite;		//What audio will play here?
	public float soundVolume;		//How loud is the sound playing?

	//The player will activate a sound bit if they inspect this.
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			if(other.gameObject.GetComponent<PlayerMovement>().isInteracting == true)
			{
				if(GameObject.Find("SoundPlayer").GetComponent<AudioSource>().isPlaying == false)
					GameObject.Find("SoundPlayer").GetComponent<AudioSource>().PlayOneShot(soundBite,1f);
			}
			other.gameObject.GetComponent<PlayerMovement>().isInteracting = false;
		}
	}

}
