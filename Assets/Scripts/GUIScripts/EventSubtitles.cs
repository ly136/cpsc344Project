using UnityEngine;
using System.Collections;

// This event contains subtitles for audio, inspect, and approach events.
public class EventSubtitles : MonoBehaviour {

    public int[] titleTime;
	public string[] subTitles;				// The string messages that will be outputted for this event.
	public static bool alreadyDisplaying;	// Is a text array already sent to the PlayerMessage? 

	// If the player approaches this area as well as if the tag on this gameobject is SPECIFICALLY VisualText, gives the player a message.
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player" && alreadyDisplaying == false)
		{
			if(gameObject.tag == "VisualText")
				GiveSubTitlesToPlayer();
		}
	}

	// Displays the subtitles when the player inspects this event. Only works if the gameObject is tagged "InspectEvent"
	void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player" && alreadyDisplaying == false)
		{
			if(gameObject.tag == "InspectEvent" && other.GetComponent<PlayerActions>().isInteracting == true)
				GiveSubTitlesToPlayer();
		}
	}

	// This allows the subtitles to reset, allowing the player to reinspect the event once the subtitles are done displaying.
	void ResetAlreadyDisplaying()
	{
		alreadyDisplaying = false;
	}

	// This finds the Player Message object and gives the subtitles to them.
	public void GiveSubTitlesToPlayer()
	{
		GameObject.Find("Main Camera").GetComponent<PlayerMessage>().AssignNewMessageArray(subTitles,titleTime);
		alreadyDisplaying = true;

		float timeToReset = GameObject.Find("Main Camera").GetComponent<PlayerMessage>().timeToChange * subTitles.Length;
		Invoke("ResetAlreadyDisplaying",timeToReset);
	}
		
}
