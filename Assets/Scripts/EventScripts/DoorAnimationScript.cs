using UnityEngine;
using System.Collections;

public class DoorAnimationScript : MonoBehaviour {
	GameObject Door;
	bool flag = false;


void OnTriggerEnter(Collider Other)
{ 
	if(Other.gameObject.tag == "Player")
	{
			gameObject.GetComponent<Animation>().Play("Opening");
			flag = true;
	}
}
}

