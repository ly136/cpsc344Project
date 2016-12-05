using UnityEngine;
using System.Collections;

// This script allows for subtitles for the incinerator events.
// Attatch this script to all objects associated with the incinerator.

public class IncineratorSubtitles : MonoBehaviour {

	public int[] burnSubTitleTime;					// The amount of time that the burning subtitles take
	public string[] burnSubTitles;					// The subtitles to display for the burning subtitles

	public int[] lastOneSubTitleTime;				// The amount of time that the subtitles for this object to take if it's the last one
	public string[] lastOneSubTitles;				// The subititle to display when this object is the last one in the room.

}
