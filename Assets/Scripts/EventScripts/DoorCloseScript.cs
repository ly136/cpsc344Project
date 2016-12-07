using UnityEngine;
using System.Collections;

public class DoorCloseScript : MonoBehaviour {
	public GameObject Door;

	void OnTriggerEnter(Collider Other)
	{ 
		if(Other.gameObject.tag == "Player")
		{
			gameObject.GetComponent<Animation>().Play("Closing");

		}
}
}
