using UnityEngine;
using System.Collections;

// This script keeps track of how many events the player "picks up" and after reaching a set amount, prevents the player from picking up any remaining items.

public class LimitPlayerInv : MonoBehaviour {

	public int maxItemsPickedUp;			//The maximum number of items that the player can pick up.
	public bool reachedMax;					//Has the maxItemPickedUp reached its max?

	// Every time the player picks up an item, maxItemsPickedUp is decremented. Once it reaches 0, any remaining items get their tag changed to untagged.
	public void DecrementItemNumber()
	{
		maxItemsPickedUp--;

		if(maxItemsPickedUp < 1)
			reachedMax = true;
	}

}
