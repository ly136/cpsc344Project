using UnityEngine;
using System.Collections;

//This activates an event if the player walks into it, or if the player inspects it within its range.

public class ScriptedEvent : MonoBehaviour {

	public bool isActivatedByInspect = false;

	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.name == "Player")
		{
			if(isActivatedByInspect == true && other.gameObject.GetComponent<PlayerMovement>().isInteracting == true)
			{
				print("Activate cutscene by inspecting here!");
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "Player")
		{
			if(isActivatedByInspect == false)
			{
				print("Activate cutscene by entering here!");
			}
		}
	}


}
