using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*  This script keeps track of what events are currently in the room as well as what needs to be spawned in once the first item is done.	
 *  This works in that all of the events that need to occur are in the room. Deactivate all of the events that aren't going to be active when the player
 *  first enters the room and add those to eventList. Each index point in numbOfEventsToSpawn corresponds to how many events in eventList will be reactivated
 *  when currEventsComplete == numbOfEventsToSpawn[currIndex]. 
 * 
 * 	Ex: In the initial round, I want 4 events to be done before activating more, so numbOfEventsToSpawn[0] = 4. 
 * 	Ex: In the next round, I want 2 new events to be activated. numbOfEventsToSpawn[1] = 2
 */

public class RoomEvents : MonoBehaviour {

	public List<GameObject> eventList = new List<GameObject>();			//Contains all of the events that are associated with bein activated in a aequence
	public int[] numbEventsActivatedPerRound;							//How many events will activate in each iteration?

	private int currOnEventActiveIndex = 0;								//The current index that works with the int array
		
	//Activates the next set of events into the room.
	void ActivateNextEvents()
	{
		int numbActivatedEvents = 0;
		int eventListIndex = 0;

		if(currOnEventActiveIndex + 1 < numbEventsActivatedPerRound.Length)
		{
			currOnEventActiveIndex++;
			while(numbActivatedEvents != numbEventsActivatedPerRound[currOnEventActiveIndex] && eventListIndex < eventList.Count)
			{
				if(eventList[eventListIndex].GetComponent<HasSolvedEvent>().hasSolvedEvent == false)
				{
					eventList[eventListIndex].SetActive(true);
					numbActivatedEvents++;
				}
				eventListIndex++;
			}
		}
	}

	//Checks if the number of completed events if the number of finished events == the number of events needed to continue the chain.
	public void CheckIfCanActivateEvents()
	{
		int numbEventsComplete = 0;

		for(int i = 0; i < numbEventsActivatedPerRound[currOnEventActiveIndex]; i++)
		{
			if(eventList[i].activeInHierarchy == false)
				numbEventsComplete++;
			else if(eventList[i].GetComponent<HasSolvedEvent>().hasSolvedEvent == true)
				numbEventsComplete++;
		}

		if(numbEventsComplete == numbEventsActivatedPerRound[currOnEventActiveIndex])
			ActivateNextEvents();
	}
		
}
