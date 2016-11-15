using UnityEngine;
using System.Collections;

// This script checks that if the player has the items listed, it gives the player a new item.
public class CombineItems : MonoBehaviour {

	public string[] itemList;				//How many items does the player need in order to receive the new item?
	public string newItem;					//What item will the player get once the player has all of the items?
	public bool hasReceivedItem;			//Did the player receive the item?

	// Checks if the player has all of the items listed in the list.
	void Update () 
	{
		if(hasReceivedItem == false)
		{
			int itemCount = 0;
			for(int i = 0; i < itemList.Length; i++)
			{
				if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerActions>().CheckIfPlayerHasItem(itemList[i]))
					itemCount++;
			}

			if(itemCount == itemList.Length)
				GetNewItem();
		}
	}

	// Removes all of the items from the player and replaces it with one item. Deactivates this script as well.
	void GetNewItem()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerActions>().RemoveAllItemsFromInventory();
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerActions>().AddToInventory(newItem);
		GameObject.Find("Main Camera").GetComponent<PlayerMessage>().DisplayOneMessage("Combined items to obtain " + newItem);
		hasReceivedItem = true;
	}
		
}
