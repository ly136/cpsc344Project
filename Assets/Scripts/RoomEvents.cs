using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*  This script keeps track of what events are currently in the room as well as what needs to be spawned in once the first item is done.	
 *  This works in that the first event(s) is/are already placed in the scene. Then, IN ORDER OF WHEN THEY SHOULD APPEAR, have the eventList contain the prefabs of 
 *  the events that it needs to spawn into the room. eventPlacement contains the gameobjects where these events will be placed at (ALSO IN THE SAME ORDER AS THE
 * 	eventList OBJECTS. The numbOfEventsToSpawn indicate how many events will be in the current scene at that indec value. (So at index 0 should be the number of
 * 	events currently in the room right now, and index1 has the number of events that will spawn once all of those events in the room are gone.)
 */

public class RoomEvents : MonoBehaviour {

	public List<GameObject> eventList = new List<GameObject>();			//Contains all of the events that are in the room
	public List<GameObject> eventPlacement = new List<GameObject>();	//Contains the places where the event will spawn accordingly
	public int[] numbOfEventsToSpawn;									//How many events will spawn in each iteration?
	public int currEventsComplete;										//How many events did the player complete that are related to this script?

	private int currOnEventSpawnIndex = 0;								//The current index that works with the int array

	//Spawns the next set of events into the room
	public void SpawnEvents()
	{
		for(int i = 0; i < numbOfEventsToSpawn[currOnEventSpawnIndex]; i++)
		{
			Instantiate(eventList[i], eventPlacement[i].transform.position, Quaternion.identity);
			eventList.Remove(eventList[i]);
			eventPlacement.Remove(eventPlacement[i]);
		}

		if(currOnEventSpawnIndex < numbOfEventsToSpawn.Length)
			currOnEventSpawnIndex++;
	}

	//Checks if the number of event list isn't at the end as well as checking if all of the events active right now are done.
	public bool CheckIfCanSpawnMore()
	{
		if(currOnEventSpawnIndex < numbOfEventsToSpawn.Length && currEventsComplete == numbOfEventsToSpawn[currOnEventSpawnIndex])
			return true;
		return false;
	}

}
