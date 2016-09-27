using UnityEngine;
using System.Collections;

//This activates an event if the player walks into it.

public class ApproachEvent : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "Player")
		{
			print("Activate cutscene by entering here!");
		}
	}
}
