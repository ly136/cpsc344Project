using UnityEngine;
using System.Collections;

//This is put on all events that can be solved. It simply has one variable, so any event can have this regardless on what it is.
public class HasSolvedEvent : MonoBehaviour {

	public bool hasSolvedEvent;		//Has this event been solved?

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

}
