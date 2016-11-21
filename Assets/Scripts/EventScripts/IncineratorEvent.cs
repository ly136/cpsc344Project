using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// This script is exclusive to the incinerator event. First, it takes in X items from the player; doesn't matter what. Then, with each item, it plays a 
// specific sound bite for each one when it's used. After it's done, it'll then play a sound bite commenting on the item that the player didn't use.
public class IncineratorEvent : MonoBehaviour {

	public List<AudioClip> usingItemSounds = new List<AudioClip>();			//What are the sound clips that are played when the player uses an item?
	public List<AudioClip> lastItemSoundList = new List<AudioClip>();		//What sound plays when the script is done?
	public GameObject[] itemsPickedUp;										//The items that this object is associated with.
	public GameObject soundPlayer;											//The gameobject used to play the sound bites.
	public int numbItemsAccepted;											//How many items can this event accept?
	public float volume;													//What is the volume of the sounds?
	public bool hasFinished;												//dDid this script do its job?
	
	// Once numbItemsAccepted == 0, this event plays a sound depending on what the player didn't pick up. After that sound has finished playing,
	// this gameobject the event is associated with is deactivated.
	void Update () 
	{
		if(hasFinished == true && soundPlayer.GetComponent<AudioSource>().isPlaying == false)
		{
			gameObject.SetActive(false);
		}
		else if(gameObject.GetComponent<HasSolvedEvent>().GetIfSolvedEvent() == true && soundPlayer.GetComponent<AudioSource>().isPlaying == false)
		{
			if(hasFinished == false)
			{
				for(int i = 0; i < itemsPickedUp.Length; i++)
				{
					if(itemsPickedUp[i].activeInHierarchy == true)
					{
						//Here, we assume that this object is the one that the player didn't pick up
						switch(itemsPickedUp[i].GetComponent<ItemGetNeedEvent>().itemAvailableOrNeed[0])
						{
							case "Trophy":
								soundPlayer.GetComponent<AudioSource>().PlayOneShot(lastItemSoundList[0],volume);
								break;
							case "Framed Award":
								soundPlayer.GetComponent<AudioSource>().PlayOneShot(lastItemSoundList[1],volume);
								break;
							case "Roses":
								soundPlayer.GetComponent<AudioSource>().PlayOneShot(lastItemSoundList[2],volume);
								break;
							case "Toy Dog":
								soundPlayer.GetComponent<AudioSource>().PlayOneShot(lastItemSoundList[3],volume);
								break;
							case "Family Sketch":
								soundPlayer.GetComponent<AudioSource>().PlayOneShot(lastItemSoundList[4],volume);
								break;
							case "Sunflowers":
								soundPlayer.GetComponent<AudioSource>().PlayOneShot(lastItemSoundList[5],volume);
								break;
						}
						hasFinished = true;
						break;
					}
				}	
			}
		}
	}

	//  When the player is inspecting this, they will "use" their items on this.
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.name == "Player")
		{
			PlayerActions player = other.gameObject.GetComponent<PlayerActions>();
			if(player.isInteracting == true)
			{
				if(soundPlayer.GetComponent<AudioSource>().isPlaying == false)
				{
					if(gameObject.GetComponent<HasSolvedEvent>().GetIfSolvedEvent() == false && player.GetInventoryLength() > 0)
					{
						//We look at the item that the player has given this and play an approperiate sound
						switch(player.GetItem(0))
						{
							case "Trophy":
								soundPlayer.GetComponent<AudioSource>().PlayOneShot(usingItemSounds[0],volume);
								break;
							case "Framed Award":
								soundPlayer.GetComponent<AudioSource>().PlayOneShot(usingItemSounds[1],volume);
								break;
							case "Roses":
								soundPlayer.GetComponent<AudioSource>().PlayOneShot(usingItemSounds[2],volume);
								break;
							case "Toy Dog":
								soundPlayer.GetComponent<AudioSource>().PlayOneShot(usingItemSounds[3],volume);
								break;
							case "Family Sketch":
								soundPlayer.GetComponent<AudioSource>().PlayOneShot(usingItemSounds[4],volume);
								break;
							case "Sunflowers":
								soundPlayer.GetComponent<AudioSource>().PlayOneShot(usingItemSounds[5],volume);
								break;
						}
						GameObject.Find("Main Camera").GetComponent<PlayerMessage>().DisplayOneMessage("Tossed " + player.GetItem(0));
						player.RemoveFromInventory(player.GetItem(0));
						numbItemsAccepted--;

						if(numbItemsAccepted == 0)
							gameObject.GetComponent<HasSolvedEvent>().SetIfSolvedEvent(true);
					}	
				}
				player.isInteracting = false;
			}
		}
	}
}
