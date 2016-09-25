using UnityEngine;
using System.Collections;

// This class will simply have the player controls. This class will have an interact button. This will do various things with the enviroment.
// I used https://www.youtube.com/watch?v=5pkeRlpjFzQ&index=4&list=WL to help fix some bugs!

using System;

public class PlayerMovement : MonoBehaviour {

	public float walkAcceleleration = 5f;		//How fast will the player accelerate?
	public float maxWalkSpeed = 10f;			//The max speed the player can move
	public float maxFallSpeed = 10f;
	public bool isInteracting = false;			//Is the player interacting with anything?
	public bool isGrounded;						//Is the player on the floor?
	public GameObject cameraControl;			//The camera control attatched to the player

	private Rigidbody playerControl;			//The rigidbody controller attatched to the player.
	private Vector3 horizontalMovement;			//Used to constrain the player's top speed
	private Vector3 verticalMovement;			//Used to constrain the player's falling speed.

	//Makes sure there's only one player in the room.
	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	//Assigns the playerController to a private variable.
	void Start()
	{
		playerControl = gameObject.GetComponent<Rigidbody>();
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
					{
						playerControl.velocity = Vector3.zero;
					}
					else
					{
						playerControl.AddRelativeForce(Input.GetAxis("Horizontal") * walkAcceleleration, 0, Input.GetAxis("Vertical") * walkAcceleleration);
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
	}

	//Checks if the player is off the ground
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Ground")
		{
			isGrounded = false;
		}
	}

	//Checks if the player is on the ground.
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Ground")
		{
			isGrounded = true;
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
