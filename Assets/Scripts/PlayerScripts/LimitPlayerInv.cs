using UnityEngine;
using System.Collections;

// This script keeps track of how many events the player "picks up" and after reaching a set amount, prevents the player from picking up any remaining items.
// To use this, this should be on an empty GameObject placed in the Scene where it is needed.

public class LimitPlayerInv : MonoBehaviour {

	public int maxItemsPickedUp;			//The maximum number of items that the player can pick up.
	public bool reachedMax;					//Has the maxItemPickedUp reached its max?

	// Every time the player picks up an item, maxItemsPickedUp is decremented. Once it reaches 0, reachedMax becomes true.
	public void DecrementItemNumber()
	{
		maxItemsPickedUp--;

		if(maxItemsPickedUp < 1)
			reachedMax = true;
	}

}
