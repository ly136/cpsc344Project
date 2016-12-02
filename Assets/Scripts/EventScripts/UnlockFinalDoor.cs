using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// This script keeps track of what areas the player has explored and increments up. Once the player has explored all of the areas, this will unlock
// the final door.
using System.Collections.Generic;

public class UnlockFinalDoor : MonoBehaviour {
	public List<string> areaVisitedNames = new List<string>();	// What were the area that the player visited? 
    public AudioClip unlockSound;

	// Allows for this object to persist in each area.
	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	//Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
	void OnEnable()
	{
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	//Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}

	// This is the method where things that need to be checked on level loading to happen
	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
	{
		switch(scene.name)
		{
			case "HubPrototype":
				// We first see if the player has visited other rooms already. If so, those warps are deactivated.
				GameObject[] warpZones = GameObject.FindGameObjectsWithTag("InspectEvent");
				for(int i = 0; i < warpZones.Length; i++)
				{
					if(areaVisitedNames.Contains(warpZones[i].GetComponent<ChangeScene>().nameOfScene))
						warpZones[i].GetComponent<ChangeScene>().enabled = false;
				}
				
				// If the player has visited all of the rooms, the final door is unlocked (either enabling the warp or it's a locked door).
				if(areaVisitedNames.Count == warpZones.Length - 1)
                {
                    GameObject.Find("DoorOfAcceptance").gameObject.GetComponent<ChangeScene>().enabled = true;
                    GameObject.Find("Main Camera").GetComponent<PlayerMessage>().DisplayOneMessage("It sounds like a new room has unlocked...");
                    GameObject.Find("SoundPlayer").GetComponent<AudioSource>().PlayOneShot(unlockSound, 1f);
                }
					
					//GetComponent<HasSolvedEvent>().SetIfSolvedEvent(true);

				break;
			case "CleanBedroom":
				areaVisitedNames.Add(scene.name);
				break;
			case "MessyBedroom":
				areaVisitedNames.Add(scene.name);
				break;
			case "CleanLivingRoom":
				areaVisitedNames.Add(scene.name);
				break;
			case "Hospital":
				areaVisitedNames.Add(scene.name);
				break;
			case "MaskRoom":
				Destroy(this.gameObject);
				break;
			default:
				break;
		}
	}


}
