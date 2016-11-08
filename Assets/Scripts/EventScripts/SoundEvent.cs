using UnityEngine;
using System.Collections;

// This script allows a sound to be played. Depending on what it's set as, it's either inspection or proximity.
// Remember to make a "SoundPlayer" object with an AudioSource component in the scene!
public class SoundEvent : MonoBehaviour {

	public GameObject playUponCompleteEvent;	//Will the sound play when this gameobject's event's complete?
	public AudioClip soundBite;					//What audio will play here?
	public float soundVolume;					//How loud is the sound playing?
	public float delayBeforePlaying;			//Is there a delay before playing the clip?

	private bool playedAlready;					//Did the clip already play?

	// If this sound event is associated with an event finishing, it'll play.
	void Update()
	{
		if(playUponCompleteEvent != null)
		{
			if(playUponCompleteEvent.GetComponent<HasSolvedEvent>().hasSolvedEvent == true && playedAlready == false)
			{
				playedAlready = true;
				Invoke("PlaySound",delayBeforePlaying);
			}
		}
	}

	//The player will activate a sound bit if they are near this or if they inspect it.
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Player" && playUponCompleteEvent == null)
		{
			PlayerActions player = other.gameObject.GetComponent<PlayerActions>();
			if(gameObject.tag == "InspectEvent")
			{
				if(player.isInteracting == true)
					Invoke("PlaySound",delayBeforePlaying);

				player.isInteracting = false;
			}		
			else
				Invoke("PlaySound",delayBeforePlaying);
		}
	}

	// Plays the sound only if the SoundPlayer is not already playing something.
	void PlaySound()
	{
		if(GameObject.Find("SoundPlayer").GetComponent<AudioSource>().isPlaying == false)
		{
			GameObject.Find("SoundPlayer").GetComponent<AudioSource>().PlayOneShot(soundBite,1f);

			// Subtitles for the event (if they exist) are called here.
			if(gameObject.GetComponent<EventSubtitles>() != null)
				gameObject.GetComponent<EventSubtitles>().GiveSubTitlesToPlayer();
		}
	}
}
