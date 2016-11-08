using UnityEngine;
using System.Collections;

// This script activates whether not the particle system for the particular object can be used.
// The gameObject needs to be attatched to the gameObject that has the event where the player can interact with.
public class ActivateParticles : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
			gameObject.transform.GetChild(0).gameObject.SetActive(true);
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
			gameObject.transform.GetChild(0).gameObject.SetActive(false);
	}
}
