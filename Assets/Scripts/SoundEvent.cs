using UnityEngine;
using System.Collections;

// This script allows a sound to be played. Depending on what it's set as, it's either inspection or proximity.
// Remember to make a "SoundPlayer" object with an AudioSource component in the scene!
public class SoundEvent : MonoBehaviour {

	public AudioClip soundBite;		//What audio will play here?
	public float soundVolume;		//How loud is the sound playing?
	public bool activateByInspect;	//Does this sound play by inspecting it?

	//The player will activate a sound bit if they are near this.
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			PlayerActions player = other.gameObject.GetComponent<PlayerActions>();
			if(activateByInspect == true)
			{
				if(player.isInteracting == true)
				{
					if(GameObject.Find("SoundPlayer").GetComponent<AudioSource>().isPlaying == false)
						GameObject.Find("SoundPlayer").GetComponent<AudioSource>().PlayOneShot(soundBite,1f);
				}
				player.isInteracting = false;
			}
			else
			{
				if(GameObject.Find("SoundPlayer").GetComponent<AudioSource>().isPlaying == false)
					GameObject.Find("SoundPlayer").GetComponent<AudioSource>().PlayOneShot(soundBite,1f);
			}

			// Insert subtitles for sound events here:
			if(gameObject.GetComponent<EventSubtitles>() != null)
				gameObject.GetComponent<EventSubtitles>().GiveSubTitlesToPlayer();
		}
	}
}
