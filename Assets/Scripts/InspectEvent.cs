using UnityEngine;
using System.Collections;

//This event occurs if the player inspects it.
//This script will contain all of the possible events that could happen. What's decided is determined by the value of EventType.

public class InspectEvent : MonoBehaviour {

	public int eventType = 0;						//What type of event is occuring here?
	public string itemAvailableOrNeed;				//What item can the player acquire/use here?
	public bool currentlyInspectingThis = false;	//Is the event currenly playing out?
	public bool canInspectAgain = false;			//Can the player reinspect this place?

	//This determines if the player is inspecting said spot and will proceed to do said action depending on what we hard coded in.
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.name == "Player")
		{
			if(other.gameObject.GetComponent<PlayerMovement>().isInteracting == true && currentlyInspectingThis == false)
			{
				currentlyInspectingThis = true;
				switch(eventType)
				{
					case 0:	//The pick up an item case.
						other.gameObject.GetComponent<PlayerInventory>().AddToInventory(itemAvailableOrNeed);
						break;
					case 1:	//The use item case.
						if(other.gameObject.GetComponent<PlayerInventory>().CheckIfPlayerHasItem(itemAvailableOrNeed) == true)
							UseItemAtSpot(other.gameObject);
						break;
				}
				other.gameObject.GetComponent<PlayerMovement>().isInteracting = false;

				if(canInspectAgain == true)
					StartCoroutine(ResetSpot(1));
				else
					DestroyObject(this.gameObject);
			}
		}
	}

	void UseItemAtSpot(GameObject player)
	{
		print("You used " + itemAvailableOrNeed);
		player.GetComponent<PlayerInventory>().RemoveFromInventory(itemAvailableOrNeed);
	}

	//Allows the player to reexamine the spot.
	IEnumerator ResetSpot(int time)
	{
		yield return new WaitForSeconds(time);
		currentlyInspectingThis = false;
	}
}
