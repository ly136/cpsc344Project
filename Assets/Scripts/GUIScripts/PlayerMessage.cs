using UnityEngine;
using System;
using System.Collections;

// This script prints out what the player has gotten to the screen. It'll appear for X seconds and then dissapear. If the player gets another item, that 
// first text will get replaced and the new text will last for X seconds.

// This also contains stuff for having subtitles. This works in that each event w/voices has a string array of sentences that represent what's going on.
// Each sentence is displyed on screen for X seconds.
public class PlayerMessage : MonoBehaviour {

	public GUIStyle fontStyle = new GUIStyle();		//The font that will be used for this
	public GUIStyle outlineStyle = new GUIStyle();	//The outline used to highlight the text.

	public float xSize;								//The X axis that the text will appear for single messages
	public float ySize;								//The Y axis that the text will appear for single messages						
	public float xEventSize;						//The X axis that the text will appear for longer messages
	public float yEventSize;						//The Y axis that the text will appear for longer messages
	public string currMessage;						//What's the current message being displayed?
	public float timeToChange;						//How long will the message be displayed for?
	public string[] messageArray;					//Where all of the messages that an event has is stored.
    public int[] arrayTime;
	private Vector3 posOfGUI;						//Used to dynamically shape the font's position on screens <= 1600x900 resolution
	private int currMessageIndex;					//Used in messageArray

	// First, this function asjusts the GUI so it's centered around the camera
	void Start()
	{
		posOfGUI = GameObject.Find("Main Camera").GetComponent<Camera>().WorldToScreenPoint(gameObject.transform.position);
	}

	// Updates the GUI as well as setting the dynamic behavior of the text.
	void OnGUI()
	{
		GUI.matrix = Matrix4x4.TRS( Vector3.zero, Quaternion.identity, new Vector3( Screen.width / 1600.0f, Screen.height / 900.0f, 1.0f ) );

		// If there's a message array to be displayed (aka a voiced event)
		if(currMessageIndex < messageArray.Length)
		{
			GUI.Label(new Rect(xEventSize + 1,yEventSize - 1,posOfGUI.x,posOfGUI.y), messageArray[currMessageIndex], outlineStyle);
			GUI.Label(new Rect(xEventSize,yEventSize,posOfGUI.x,posOfGUI.y), messageArray[currMessageIndex], fontStyle);
		}

		// If there's a single message to display (picking up something)
		GUI.Label(new Rect(xSize + 1,ySize - 1,posOfGUI.x,posOfGUI.y), currMessage, outlineStyle);
		GUI.Label(new Rect(xSize,ySize,posOfGUI.x,posOfGUI.y), currMessage, fontStyle);

	}

	// Changes the text to the next message. If it reaches the end, the message displays stops.
	void ChangeToNextMessageInArray()
	{
		if(currMessageIndex < messageArray.Length)
		{
			currMessageIndex++;
			Invoke("ChangeToNextMessageInArray", arrayTime[currMessageIndex]);
		}
	}

	// Makes the one line of text to dissapear from the screen
	void MakeMessageDissapear()
	{
		currMessage = "";
	}

	// Assigns a new message array for this script to display. Used to diaplay more than one line of messages (subtitles)
	public void AssignNewMessageArray(string[] newMessage, int[] array)
	{

        if (IsInvoking("ChangeToNextMessageInArray") == true)
			CancelInvoke("ChangeToNextMessageInArray");
        arrayTime = array;
		messageArray = newMessage;
		currMessageIndex = 0;
		Invoke("ChangeToNextMessageInArray",arrayTime[currMessageIndex]);
	}

	// Assigns one line of text to appear for X amount of seconds. Used for getting/using items/activating something.
	public void DisplayOneMessage(string newMessage)
	{
		if(IsInvoking("MakeMessageDissapear") == true)
			CancelInvoke("MakeMessageDissapear");
		
		currMessage = newMessage;
		Invoke("MakeMessageDissapear",timeToChange);
	}

}
