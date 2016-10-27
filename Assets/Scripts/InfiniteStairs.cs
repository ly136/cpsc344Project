using UnityEngine;
using System.Collections;

/*	This script will exclusively be used in the infinite staircase puzzle.
 * 	This works by that if the player enters the area where the script is activated, they will be jumped back to an earlier position. This will be handled by having
 *  a gameobject indicating the position on where the player will move to. This will only deactivate if the player examines a switch associated with it.
 */

public class InfiniteStairs : MonoBehaviour {

	public GameObject warpSpot;			//Where will the player be positioned at?

	//When the player reaches this spot where the script is active, the player teleports to the location specified by warpSpot
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			if(gameObject.transform.GetChild(0).GetComponent<HasSolvedEvent>().GetIfSolvedEvent() == false)
				other.gameObject.transform.position = warpSpot.transform.position;
		}
	}

}
