using UnityEngine;
using System.Collections;

// This is put on events that can be solved. It simply has one variable, so any event can have this regardless on what it is.
// This also checks if the event solved was part of the RoomEvent event.
// Also controls the particle events to indicate if this event is interactable of not.
public class HasSolvedEvent : MonoBehaviour {

	public bool hasSolvedEvent;		//Has this event been solved?
	public bool partOfEventChain;	//Is this object part of the RoomEvents? If so, mark it here!

	// Takes the particle emitter from the child and activates it when the player approaches this.
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player" && gameObject.transform.childCount > 0)
		{
			if(gameObject.GetComponent<HasSolvedEvent>().GetIfSolvedEvent() == false)
				gameObject.transform.GetChild(0).gameObject.SetActive(true);
		}
	}

	// When the player steps away from this object, the child will stop emitting particles
	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player" && gameObject.transform.childCount > 0)
			gameObject.transform.GetChild(0).gameObject.SetActive(false);
	}

	// If this object has its events done, it'll stop emitting particles
	void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player" && gameObject.transform.childCount > 0)
		{
			if(gameObject.transform.GetChild(0).gameObject.activeInHierarchy == true)
			{
				if(gameObject.GetComponent<HasSolvedEvent>().GetIfSolvedEvent() == true)
					gameObject.transform.GetChild(0).gameObject.SetActive(false);
			}	
		}
	}

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
