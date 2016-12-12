using UnityEngine;
using System.Collections;

/* This handles opening and closing doors. To work with locked doors, you need to attatch a gameobject with ItemGetNeedEvent to the door itself.
 * In other words:
 * 	Parent: Door object
 * 	Children: LockedEvent object (you need this in order to create locked doors)
 * 			  DoorEvent object (Every door needs this)
*/
public class DoorEvent : MonoBehaviour {

	public bool isOpen;							//Is the door currently open?
	public GameObject lockedEvent;				//This contains the GameObject that has the event which is locking the door.

	public Transform actualDoor;				//This contains the door itself.


	// If the player is interacting with the door, the door will either open or close.
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			PlayerActions player = other.gameObject.GetComponent<PlayerActions>();
			if(player.isInteracting == true)
			{
				if(lockedEvent != null)	// Does this door need something to use it?
				{
					if(lockedEvent.GetComponent<HasSolvedEvent>().GetIfSolvedEvent() == true)
						DoorOpenClose();
				}
				else
					DoorOpenClose();

				player.isInteracting = false;
			}
		}
	}

	// This open/closes the door.
	public void DoorOpenClose()
	{
		if(isOpen == true)
		{
			//Insert something with animation to close the door. This is temp.
			//actualDoor.transform.position = new Vector3(actualDoor.transform.position.x, actualDoor.transform.position.y - 6f, actualDoor.transform.position.z);
			actualDoor.GetComponent<Animation>().Play("Closing");
			isOpen = false;

		}
		else
		{
			//Insert something with animation to open the door. This is temp.
			//actualDoor.transform.position = new Vector3(actualDoor.transform.position.x, actualDoor.transform.position.y + 6f, actualDoor.transform.position.z);
			actualDoor.GetComponent<Animation>().Play("Opening");
			isOpen = true;
		}
	}
}
