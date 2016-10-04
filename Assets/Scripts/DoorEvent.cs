using UnityEngine;
using System.Collections;

//This handles opening and closing the door. Also does a check to see if the door is locked.
//To work with locked doors, you need to attatch the ItemGetNeedEvent to the door itself.
public class DoorEvent : MonoBehaviour {

	public bool isOpen;							//Is the door currently open?

	private Transform lockedEvent;				//This contains the GameObject that has the ItemGetNeedEvent.
	private Transform actualDoor;				//This contains the door itself.

	//Sets the two gameobject variables in order to allow for easier calling.
	void Start()
	{
		actualDoor = gameObject.transform.parent;
		if(actualDoor.transform.childCount > 1)
			lockedEvent = gameObject.transform.parent.transform.GetChild(1);
	}

	//If the player is interacting with the door, the door will either open or close.
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			PlayerActions player = other.gameObject.GetComponent<PlayerActions>();
			if(player.isInteracting == true)
			{
				if(lockedEvent != null)	//Does this door need something to use it?
				{
					if(lockedEvent.GetComponent<ItemGetNeedEvent>().hasSolvedEvent == true)
						DoorOpenClose();
				}
				else
					DoorOpenClose();
			}
			player.isInteracting = false;
		}
	}

	//This open/closes the door.
	void DoorOpenClose()
	{
		if(isOpen == true)
		{
			//Insert something with animation to close the door. This is temp.
			actualDoor.position = new Vector3(actualDoor.position.x, actualDoor.position.y - 2f, actualDoor.position.z);
			isOpen = false;

		}
		else
		{
			//Insert something with animation to open the door. This is temp.
			actualDoor.position = new Vector3(actualDoor.position.x, actualDoor.position.y + 2f, actualDoor.position.z);
			isOpen = true;
		}
	}
}
