using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*  This script keeps track of what events are currently in the room as well as what needs to be spawned in once the first item is done.	
 *  This works in that all of the events that need to occur are in the room. Deactivate all of the events that aren't going to be active when the player
 *  first enters the room and add those to eventList. Each index point in numbOfEventsToSpawn corresponds to how many events in eventList will be reactivated
 *  when currEventsComplete == numbEventsActivatedList[numbEventsActivatedIndex]. 
 * 
 * 	Ex: In the beginning, I want 4 events to be done before activating more...	numbEventsActivatedList[0] = 4. 
 * 		Once I reach 4 finished events, I want 2 events to activate...	 		numbEventsActivatedList[1] = 2.
 * 		Then, once I hit 2 finished events, I want to activate 3 events... 		numbEventsActivatedList[2] = 3.
 * 		After finishing those 3 events, I want to activate 5 events...	 		numbEventsActivatedList[3] = 5.
 */

public class RoomEvents : MonoBehaviour {

	public List<GameObject> eventList = new List<GameObject>();			//Contains all of the events that are associated with bein activated in a aequence
	public int[] numbEventsActivatedList;								//The # of deactivated/complete events needed to activate more + the number of events to activate after hitting said amount

	private int numbEventsActivatedIndex = 0;							//The current index that works with the int array
		
	//Activates the next set of events into the room.
	void ActivateNextEvents()
	{
		if(numbEventsActivatedIndex + 1 < numbEventsActivatedList.Length)
		{
			int eventListIndex = numbEventsActivatedList[numbEventsActivatedIndex];
			int numbActivatedEvents = 0;
			numbEventsActivatedIndex++;

			while(numbActivatedEvents != numbEventsActivatedList[numbEventsActivatedIndex] && eventListIndex < eventList.Count)
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

		if(numbEventsActivatedIndex == 0)
		{
			for(int i = 0; i < numbEventsActivatedList[numbEventsActivatedIndex]; i++)
			{
				if(eventList[i].GetComponent<HasSolvedEvent>().hasSolvedEvent == true)
					numbEventsComplete++;
			}
		}
		else
		{
			int lastValue = numbEventsActivatedList[numbEventsActivatedIndex - 1];
			int toNextValue = lastValue + numbEventsActivatedList[numbEventsActivatedIndex];
			for(int i = lastValue; i < toNextValue; i++)
			{
				if(eventList[i].GetComponent<HasSolvedEvent>().hasSolvedEvent == true)
					numbEventsComplete++;
			}
		}
			
		if(numbEventsComplete == numbEventsActivatedList[numbEventsActivatedIndex])
			ActivateNextEvents();
	}
		
}
