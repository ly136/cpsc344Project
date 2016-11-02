using UnityEngine;
using System.Collections;

// This script changes the scene the player is in to another one, via a transition. It is activated by simply approaching it, or after a set time limit.
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public bool activeUponStart;	//Will this automatically change the scene once this object is active?
	public float timeLimit;			//Is this transition forced after X time? Else, the player needs to walk into the area of the gameobject to trigger it.
	public string nameOfScene;		//What's the name of the scene to change to?

	// if a timeLimit is specified, Invoke transitionToScene at X seconds.
	void Start () 
	{
		if(activeUponStart == true)
			Invoke("TransitionToScene",timeLimit);
	}
		
	// If the player enters the hitbox of this gameobject, it loads the next scene.
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			other.GetComponent<PlayerActions>().canMove = false;
			Invoke("TransitionToScene",timeLimit);
		}
	}

	// Loads the next scene
	void TransitionToScene()
	{
		SceneManager.LoadScene(nameOfScene);
	}
}
