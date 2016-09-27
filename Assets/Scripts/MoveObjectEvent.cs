using UnityEngine;
using System.Collections;

//This activates an event if the player walks in the range of this event. In this case, the object tat the player moves toward is moved out of the way.

public class MoveObjectEvent : MonoBehaviour {

	public float moveForce;			//How strong is the force applied to the object?
	public bool isMovingLeft;		//Is this object moving to the left or right?

	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.name == "Player")
		{
			if(isMovingLeft == true)
			{
				this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(-1 * moveForce, 0,0);
			}
			else
			{
				this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(1 * moveForce, 0,0);
			}
		}
		else
		{
			this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
	}
}
