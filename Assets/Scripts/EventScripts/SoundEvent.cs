using UnityEngine;
using System.Collections;

// This script allows a sound to be played. Depending on what it's set as, it's either inspection or proximity.
// Remember to make a "SoundPlayer" object with an AudioSource component in the scene!
public class SoundEvent : MonoBehaviour {

	public GameObject soundPlayer;				//Which gameObject is suppose to play this audio?
	public GameObject playUponCompleteEvent;	//Will the sound play when this gameobject's event's complete?
	public AudioClip soundBite;					//What audio will play here?
	public float soundVolume;					//How loud is the sound playing?
	public float delayBeforePlaying;			//Is there a delay before playing the clip?
	public bool playedAlready;					//Did the clip already play?

	// If this sound event is associated with an event finishing, it'll play.
	void Update()
	{
		if(playUponCompleteEvent != null)
		{
			if(playUponCompleteEvent.GetComponent<HasSolvedEvent>().hasSolvedEvent == true && playedAlready == false)
			{
				if(IsInvoking() == false)
					Invoke("PlaySound",delayBeforePlaying);
			}
		}

		//This checks if this sound event has completly finished playing its audio (even if it got cut off early)
		if(playedAlready == true && soundPlayer.GetComponent<AudioSource>().isPlaying == false)
		{
			gameObject.GetComponent<HasSolvedEvent>().SetIfSolvedEvent(true);
			gameObject.SetActive(false);
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

	// Plays the sound. If another sound is playing, the current one is stopped.
	void PlaySound()
	{
		if(soundPlayer.GetComponent<AudioSource>().isPlaying == true)
			soundPlayer.GetComponent<AudioSource>().Stop();

		soundPlayer.GetComponent<AudioSource>().PlayOneShot(soundBite,1f);
		playedAlready = true;

		// Subtitles for the event (if they exist) are called here.
		if(gameObject.GetComponent<EventSubtitles>() != null)
			gameObject.GetComponent<EventSubtitles>().GiveSubTitlesToPlayer();
	}
}
