using UnityEngine;
using System.Collections;

//This class will simply have the player inventory. It will have basic functions too.

using System;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {

	public List<string> itemList = new List<string>();	//The items will be stored as strings, since they aren't that complicated.

	public void RemoveFromInventory(string itemToRemove)
	{
		if(itemList.Contains(itemToRemove) == true)
		{
			itemList.Remove(itemToRemove);
			print("You removed " + itemToRemove);
		}
	}

	public void AddToInventory(string itemToAdd)
	{
		itemList.Add(itemToAdd);
		print("You got " + itemToAdd);
	}

	public bool CheckIfPlayerHasItem(string itemToCheck)
	{
		if(itemList.Contains(itemToCheck))
			return true;
		return false;
	}

}
