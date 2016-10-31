using UnityEngine;
using System.Collections;

// This object takes all of the switch objects that it's associated with an checks if all of them are activated.
public class SwitchReceiver : MonoBehaviour {

	public GameObject[] switchInspectObjects;	//Array of all of the switch objects that this event is associated with.

	//If all of the switch objects have been activated, this event is solved.
	public void CheckSwitchObjects()
	{
		for(int i = 0; i < switchInspectObjects.Length; i++)
		{
			if(switchInspectObjects[i].GetComponent<SwitchInspect>().isSwitchActivated == false)
			{
				gameObject.GetComponent<HasSolvedEvent>().SetIfSolvedEvent(false);
				return;
			}
		}
		gameObject.GetComponent<HasSolvedEvent>().SetIfSolvedEvent(true);
	}

}
