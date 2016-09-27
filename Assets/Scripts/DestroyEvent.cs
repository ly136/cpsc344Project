using UnityEngine;
using System.Collections;

//This is called in certain events to remove it from the scene.

public class DestroyEvent : MonoBehaviour {

	//This checks for certain scripts on the gameobject to see if any of them have been activated.
	void Update () 
	{
		if(gameObject.GetComponent<ItemGetNeedEvent>() != null)
		{
			if(gameObject.GetComponent<ItemGetNeedEvent>().hasSolvedEvent == true)
			{
				Destroy(gameObject);
			}
		}
	}
}
