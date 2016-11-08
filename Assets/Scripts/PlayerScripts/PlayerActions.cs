using UnityEngine;
using System.Collections.Generic;

// This class will simply have the player controls. This class will have an interact button. This will do various things with the enviroment. 
// This will also contain the player's inventory as well as methods to modify it.
// I used https://www.youtube.com/watch?v=5pkeRlpjFzQ&index=4&list=WL to help fix some bugs regarding movement.

public class PlayerActions : MonoBehaviour {

	public GameObject cameraControl;					//The camera control attatched to the player
	public List<string> itemList = new List<string>();	//The items the player will collect will be stored as strings, since they aren't that complicated.

	public float walkAcceleleration = 100f;				//How fast will the player accelerate?
	public float maxWalkSpeed = 2f;						//The max speed the player can move
	public float maxFallSpeed = 10f;
	public bool canMove = true;							//Can the player move around now?
	public bool isInteracting = false;					//Is the player interacting with anything?
	public bool isGrounded = false;						//Is the player on the floor?

	private Rigidbody playerControl;					//The rigidbody controller attatched to the player.
	private Vector3 horizontalMovement;					//Used to constrain the player's top speed
	private Vector3 verticalMovement;					//Used to constrain the player's falling speed.

	//Assigns the playerController to a private variable.
	void Start()
	{
		playerControl = gameObject.GetComponent<Rigidbody>();
	}
	
	//Checks if the player's hit the interact button. Else, the player is moving around.
	void Update () 
	{
		if(canMove == true)
		{
			if(Input.GetKeyDown(KeyCode.E) == true && isInteracting == false)
			{
				isInteracting = true;
				Invoke("ResetInspecting",0.5f);
			}
				
			transform.rotation = Quaternion.Euler(0,cameraControl.GetComponent<MouseCamera>().currentYRotation,0);
			if(isGrounded == false)
			{
				verticalMovement = new Vector3(0,playerControl.velocity.y,0);
				if(verticalMovement.magnitude > maxFallSpeed)
				{
					verticalMovement.Normalize();
					verticalMovement *= maxFallSpeed;
					playerControl.velocity = verticalMovement;
				}
			}
			else
			{
				if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
					playerControl.velocity = Vector3.zero;
				else
				{
					Vector3 moveForce = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
					gameObject.GetComponent<Rigidbody>().AddRelativeForce(moveForce * walkAcceleleration);
					horizontalMovement = new Vector3(playerControl.velocity.x, 0, playerControl.velocity.z);
					if(horizontalMovement.magnitude > maxWalkSpeed)
					{
						horizontalMovement.Normalize();
						horizontalMovement *= maxWalkSpeed;
						playerControl.velocity = horizontalMovement;
					}
				}
			}
		}
	}

	//Checks if the player is off the ground.
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Ground")
			isGrounded = false;
	}

	//If the player is within range of an interactive object, this will make the player inspect it.
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Ground")
			isGrounded = true;
	}

	// If the player is still "inspecting" something after half of a second, it is manually reset back to normal.
	void ResetInspecting()
	{
		if(isInteracting == true)
			isInteracting = false;
	}

	//Removes an item from the inventory
	public void RemoveFromInventory(string itemToRemove)
	{
		if(CheckIfPlayerHasItem(itemToRemove) == true)
		{
			itemList.Remove(itemToRemove);
			GameObject.Find("Main Camera").GetComponent<PlayerMessage>().DisplayOneMessage("Used " + itemToRemove);
		}
	}

	// Removes all items from the player's inventory
	public void RemoveAllItemsFromInventory()
	{
		itemList.Clear();
	}

	//Adds an item to the inventory.
	public void AddToInventory(string itemToAdd)
	{
		itemList.Add(itemToAdd);
		GameObject.Find("Main Camera").GetComponent<PlayerMessage>().DisplayOneMessage("Obtained " + itemToAdd);
	}

	//Checks if the player has the said item in their inventory and returns true if they do.
	public bool CheckIfPlayerHasItem(string itemToCheck)
	{
		if(itemList.Count == 0)
			return false;
		else if(itemList.Contains(itemToCheck))
			return true;
		return false;
	}

	//Returns the item at the currentIndex
	public string GetItem(int index)
	{
		return itemList[index];
	}

	//Returns the length of the inventory
	public int GetInventoryLength()
	{
		return itemList.Count;
	}
}
