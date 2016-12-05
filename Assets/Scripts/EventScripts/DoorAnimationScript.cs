using UnityEngine;
using System.Collections;

public class DoorAnimationScript : MonoBehaviour {
	GameObject Door;
	protected Animation test;

void OnTriggerEnter(Collider Other)
{ 
	test = GetComponent<Animation>();
	if(Other.gameObject.tag == "Player")
	{
		test.Play("Opening");
	}
}

void OnTriggerExit(Collider Other)
{
	if(Other.gameObject.tag == "Player")
	{
		test.Play("Closing");
	}
}    
}
