using UnityEngine;
using System.Collections;

//This event occurs if the player inspects it. The player will be given an item/uses an item if they have it.

public class ItemGetNeedEvent : MonoBehaviour {

	public string itemAvailableOrNeed;				//What item can the player acquire/use here?
	public bool isUsingItemEvent;					//Is the player using an item here?
	public bool currentlyInspectingThis;			//Is the event currenly playing out?
	public bool hasSolvedEvent;						//Has the event item been gotten or did the player solve it?

	//This determines if the player is inspecting said spot and will proceed to do said action depending on what we hard coded in.
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.name == "Player")
		{
			if(other.gameObject.GetComponent<PlayerMovement>().isInteracting == true && currentlyInspectingThis == false)
			{
				currentlyInspectingThis = true;
				if(isUsingItemEvent == true)
				{
					if(other.gameObject.GetComponent<PlayerInventory>().CheckIfPlayerHasItem(itemAvailableOrNeed) == true)
					{
						print("You used " + itemAvailableOrNeed);
						other.gameObject.GetComponent<PlayerInventory>().RemoveFromInventory(itemAvailableOrNeed);
						hasSolvedEvent = true;
					}
				}
				else
				{
					other.gameObject.GetComponent<PlayerInventory>().AddToInventory(itemAvailableOrNeed);
					hasSolvedEvent = true;
				}
				other.gameObject.GetComponent<PlayerMovement>().isInteracting = false;
			}
		}
	}
}
