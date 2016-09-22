using UnityEngine;
using System.Collections;

//This class will simply have the player controls. This class will have an interact button. This will do various things with the enviroment.

using System;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed;						//How fast is the player moving?
	public bool isInteracting = false;			//Is the player interacting with anything?

	private CharacterController playerControl;	//The character controller attatched to the player.

	//Makes sure there's only one player in the room.
	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	//Assigns the playerController to a private variable.
	void Start()
	{
		playerControl = gameObject.GetComponent<CharacterController>();
	}
	
	//Checks if the player's hit the interact button. Else, the player is moving around.
	void Update () 
	{
		if(isInteracting == false)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				print("You're interacting!");
				isInteracting = true;
				StartCoroutine(NotInteractingAnymore(2f));
			}
			else
			{
				Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= moveSpeed;
				playerControl.Move(moveDirection * Time.deltaTime);
			}
		}
	}

	//This is called in order to allow the player to move again.
	IEnumerator NotInteractingAnymore(float time)
	{
		yield return new WaitForSeconds(time);
		print("You can interact again!");
		isInteracting = false;
	}
}
