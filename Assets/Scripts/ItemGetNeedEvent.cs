using UnityEngine;
using System.Collections;

//This event occurs if the player inspects it. The player will be given an item/uses an item if they have it.
using System.Collections.Generic;

public class ItemGetNeedEvent : MonoBehaviour {

	public List<string> itemAvailableOrNeed = new List<string>();			//What items can the player acquire/use here?
	public bool isUsingItemEvent;											//Is the player using an item here?
	public bool hasSolvedEvent;												//Has the event item been gotten or did the player solve it?

	//This determines if the player is inspecting said spot and will proceed to do said action depending on what we hard coded in.
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.name == "Player")
		{
			if(other.gameObject.GetComponent<PlayerMovement>().isInteracting == true)
			{
				if(hasSolvedEvent == false)
				{
					if(isUsingItemEvent == true)
					{
						string firstItem = itemAvailableOrNeed[0];
						if(other.gameObject.GetComponent<PlayerInventory>().CheckIfPlayerHasItem(firstItem) == true)
						{
							print("You used " + itemAvailableOrNeed);
							other.gameObject.GetComponent<PlayerInventory>().RemoveFromInventory(firstItem);
							itemAvailableOrNeed.Remove(firstItem);
							if(itemAvailableOrNeed.Count == 0)
							{
								hasSolvedEvent = true;
							}
						}
					}
					else
					{
						other.gameObject.GetComponent<PlayerInventory>().AddToInventory(itemAvailableOrNeed[0]);
						hasSolvedEvent = true;
					}
				}

			}
			other.gameObject.GetComponent<PlayerMovement>().isInteracting = false;
		}
	}
}
