using UnityEngine;
using System.Collections;

// This event contains subtitles for said event.
public class EventSubtitles : MonoBehaviour {

	public string[] subTitles;
	public bool hasGivenSubs;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player" && hasGivenSubs == false)
		{
			if(gameObject.tag == "InspectEvent")
			{
				if(other.GetComponent<PlayerActions>().isInteracting == true)
					GameObject.Find("Main Camera").GetComponent<PlayerMessage>().AssignNewMessageArray(subTitles);

				hasGivenSubs = true;
			}
			else if(gameObject.tag == "ApproachEvent")
			{
				GameObject.Find("Main Camera").GetComponent<PlayerMessage>().AssignNewMessageArray(subTitles);
				hasGivenSubs = true;
			}
		}
	}
}
