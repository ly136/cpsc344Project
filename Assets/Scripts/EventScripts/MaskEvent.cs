using UnityEngine;
using System.Collections;

// This script is used in the mask room. It's identical to ItemGetNeed, except that it is turning off the second child of the parent object as well.

public class MaskEvent : MonoBehaviour {

	public string itemGet;	// What is the name of the item that the player will get?

	//Checks whether this event will be deactivated once it's complete.
	void Update()
	{
		if (gameObject.GetComponent<HasSolvedEvent> ().GetIfSolvedEvent () == true) {
			gameObject.SetActive(false);
			gameObject.transform.GetChild(1).gameObject.SetActive(false);
		}
	}

	//This determines if the player is inspecting said spot and will either pick up an item or use an item.
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.name == "Player")
		{
			PlayerActions player = other.gameObject.GetComponent<PlayerActions>();
			if(player.isInteracting == true)
			{
				if(gameObject.GetComponent<HasSolvedEvent>().GetIfSolvedEvent() == false)
				{
					bool addSuccess = player.AddToInventory(itemGet);
					if(addSuccess == true)
					{
						GameObject.Find("Main Camera").GetComponent<PlayerMessage>().DisplayOneMessage("Obtained " + itemGet);
						gameObject.GetComponent<HasSolvedEvent>().SetIfSolvedEvent(true);
					}
				}
				player.isInteracting = false;
			}
		}
	}
}
