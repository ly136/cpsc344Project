using UnityEngine;
using System.Collections;

// This plays a sound when the player is within range and get's lounder when the player gets closer to this. Used in the phone ringing puzzle.

public class SoundProximity : MonoBehaviour {

	public int playerDisitance;			//How far away is the player from this?
	public AudioClip soundClip;			//What sound should play?
	public float startVolume;			//How loud should the player hear this from the farthest disitance away?

	// When the player gets closer to the object, the sound plays louder.
	void Update () 
	{
		if(GameObject.Find("SoundPlayer").GetComponent<AudioSource>().isPlaying == false)
		{
			playerDisitance = Mathf.Abs((int)Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position));

			if(playerDisitance < 20)
			{
				if(playerDisitance >= 15)
					GameObject.Find("SoundPlayer").GetComponent<AudioSource>().PlayOneShot(soundClip,startVolume);
				else if(playerDisitance >= 10)
					GameObject.Find("SoundPlayer").GetComponent<AudioSource>().PlayOneShot(soundClip,startVolume + 1f);
				else if(playerDisitance >= 5)
					GameObject.Find("SoundPlayer").GetComponent<AudioSource>().PlayOneShot(soundClip,startVolume + 2f);
				else
					GameObject.Find("SoundPlayer").GetComponent<AudioSource>().PlayOneShot(soundClip,startVolume + 3f);
			}
		}
	}
}
