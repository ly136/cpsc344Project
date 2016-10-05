using UnityEngine;
using System.Collections;

// This class will be used to see if inspecting this object will trigger a switch.
public class SwitchInspect : MonoBehaviour {

	public bool isSwitchActivated;		//Is the switch turned on?

	// This checks if the player has inspected the object to turn on/off the switch.
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			if(other.gameObject.GetComponent<PlayerActions>().isInteracting == true)
			{
				if(isSwitchActivated == false)
				{
					isSwitchActivated = true;
					print("I'm activated!");
				}
				else
				{
					isSwitchActivated = false;
					print("I'm deactivated!");
				}
				GameObject.FindGameObjectWithTag("SwitchDoor").transform.GetChild(1).GetComponent<SwitchReceiver>().CheckSwitchObjects();
			}
			other.gameObject.GetComponent<PlayerActions>().isInteracting = false;
		}
	}
}
