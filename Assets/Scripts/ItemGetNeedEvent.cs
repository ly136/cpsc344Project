using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// This event occurs if the player inspects it. The player will be given an item/uses an item if they have it. 
// If the player is getting an item, the item list MUST have only one item.
public class ItemGetNeedEvent : MonoBehaviour {

	public List<string> itemAvailableOrNeed = new List<string>();			//What items can the player acquire/use here?
	public bool isUsingItemEvent;											//Is the player using an item here?
	public bool deactivateOnComplete;										//Will this object get deactivated upon being complete?

	//Checks whether this event will be destroyed once it's complete.
	void Update()
	{
		if(gameObject.GetComponent<HasSolvedEvent>().GetIfSolvedEvent() == true && deactivateOnComplete == true)
			gameObject.SetActive(false);
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
					if(isUsingItemEvent == true)
					{
						//We look through the player's inventory to see if this event has an item that the player can use. If the player has multiple items
						for(int i = 0; i < player.GetInventoryLength(); i++)
						{
							string currItem = player.GetItem(i);
							if(itemAvailableOrNeed.Contains(currItem) == true)
							{
								player.RemoveFromInventory(currItem);
								itemAvailableOrNeed.Remove(currItem);
								if(itemAvailableOrNeed.Count == 0)
									gameObject.GetComponent<HasSolvedEvent>().SetIfSolvedEvent(true);
								break;
							}
						}
					}
					else
					{
						player.AddToInventory(itemAvailableOrNeed[0]);
						gameObject.GetComponent<HasSolvedEvent>().SetIfSolvedEvent(true);
					}

					gameObject.GetComponent<HasSolvedEvent>().CheckIfPartOfChainEvent();
				}
				player.isInteracting = false;
			}
		}
	}
		
}
