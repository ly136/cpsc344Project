using UnityEngine;
using System.Collections;

// This event contains subtitles for said event.
public class EventSubtitles : MonoBehaviour {

	public string[] subTitles;		// The string messages that will be outputted for this event.
	public bool hasGivenSubs;		// Did the subtitles for this event has already been given?

	// This finds the Player Message object and gives the subtitles to them. This method is called in specific scipts.
	public void GiveSubTitlesToPlayer()
	{
		if(hasGivenSubs == false)
		{
			GameObject.Find("Main Camera").GetComponent<PlayerMessage>().AssignNewMessageArray(subTitles);
			hasGivenSubs = true;
		}
	}
}
