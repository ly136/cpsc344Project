using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// This script first finds an object that the player didn't pick up, chooses an approperiate sound clip, and activates this object's Sound Event
public class IncineratorChooseSound : MonoBehaviour {

	public List<AudioClip> soundList = new List<AudioClip>();		//what sounds does this script have?
	public GameObject completedObject;								//Is this object completed?
	public bool hasFinished;										//did this script do its job?
	
	// If the completed gameobject, is done, We find a Gameobject that's tagged InspectEvent, and if it's the item that the player didn't pick it up, a
	// sound is choosen for this gameObject's SoundEvent script.
	void Update () 
	{
		if(completedObject.GetComponent<HasSolvedEvent>().GetIfSolvedEvent() == true && hasFinished == false)
		{
			GameObject[] notGotten = GameObject.FindGameObjectsWithTag("InspectEvent");
			for(int i = 0; i < notGotten.Length; i++)
			{
				if(notGotten[i].activeInHierarchy == true)
				{
					//Here, we assume that this object is the one that the player didn't pick up
					switch(notGotten[i].GetComponent<ItemGetNeedEvent>().itemAvailableOrNeed[0])
					{
						case "Trophy":
							notGotten[i].GetComponent<SoundEvent>().soundBite = soundList[0];
							break;
						case "Framed Awards":
							notGotten[i].GetComponent<SoundEvent>().soundBite = soundList[1];
							break;
						case "Roses":
							notGotten[i].GetComponent<SoundEvent>().soundBite = soundList[2];
							break;
						case "Toy Dogs":
							notGotten[i].GetComponent<SoundEvent>().soundBite = soundList[3];
							break;
						case "Family Sketch":
							notGotten[i].GetComponent<SoundEvent>().soundBite = soundList[4];
							break;
						case "Flowers":
							notGotten[i].GetComponent<SoundEvent>().soundBite = soundList[5];
							break;
					}
					notGotten[i].GetComponent<SoundEvent>().enabled = true;
					hasFinished = true;
					break;
				}
			}
		}
	}
}
