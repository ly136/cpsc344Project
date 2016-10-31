using UnityEngine;
using System.Collections;

// This is put on all events that can be solved. It simply has one variable, so any event can have this regardless on what it is.
// This also checks if the event solved was part of the RoomEvent event.
public class HasSolvedEvent : MonoBehaviour {

	public bool hasSolvedEvent;		//Has this event been solved?
	public bool partOfEventChain;	//Is this object part of the RoomEvents? If so, mark it here!

	//Returns true or fale if the event has been solved.
	public bool GetIfSolvedEvent()
	{
		if(hasSolvedEvent == true)
			return true;
		return false;
	}

	//Sets the solved event to what the given parameters say.
	public void SetIfSolvedEvent(bool newValue)
	{
		hasSolvedEvent = newValue;
	}

	//Does a check to see if this event is part of the RoomEvents script if it exists.
	public void CheckIfPartOfChainEvent()
	{
		if(GameObject.FindGameObjectWithTag("RoomEvents") != null && partOfEventChain == true)
			GameObject.FindGameObjectWithTag("RoomEvents").GetComponent<RoomEvents>().CheckIfCanActivateEvents();
	}

}
