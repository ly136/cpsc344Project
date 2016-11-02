using UnityEngine;
using System.Collections;

// This script checks if the player has the items listed, it gives the player a new item.

public class CombineItems : MonoBehaviour {

	public string[] itemList;				//How many items does the player need in order to receive the new item?
	public string newItem;					//What item will the player get once the player has all of the items?
	public bool hasReceivedItem;			//Did the player receive the item?

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
