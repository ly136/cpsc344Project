using UnityEngine;
using System.Collections;

// This class will be used to see if inspecting this object will trigger a switch.
public class SwitchInspect : MonoBehaviour {

	public GameObject switchReceiver;	//Which Gameobject are these activating towards?
	public bool isSwitchActivated;		//Is the switch turned on?

	// Takes the particle emitter from the child and activates it when the player approaches this
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
			gameObject.transform.GetChild(0).gameObject.SetActive(true);
	}

	// When the player steps away from this object, the child  will stop emitting particles
	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
			gameObject.transform.GetChild(0).gameObject.SetActive(false);
	}

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
					GameObject.Find("Main Camera").GetComponent<PlayerMessage>().DisplayOneMessage("It's now on.");
				}
				else
				{
					isSwitchActivated = false;
					GameObject.Find("Main Camera").GetComponent<PlayerMessage>().DisplayOneMessage("It's now off.");
				}
				switchReceiver.GetComponent<SwitchReceiver>().CheckSwitchObjects();
			}
			other.gameObject.GetComponent<PlayerActions>().isInteracting = false;
		}
	}
}
