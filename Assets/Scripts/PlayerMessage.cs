using UnityEngine;
using System.Collections;

// This script prints out what the player has gotten to the screen. It'll appear for X seconds and then dissapear. If the player gets another item, that 
// first text will get replaced and the new text will last for 3 seconds.
public class PlayerMessage : MonoBehaviour {

	public GUIStyle fontStyle = new GUIStyle();		//The font that will be used for this
	public float xSize;								//The X axis that the text will appear
	public float ySize;								//The Y axis that the text will appear							
	public string currMessage;						//What's the current message being displayed?
	public float timeToDissapear;					//How long will the message be displayed for?

	private Vector3 posOfGUI;						//Used to dynamically shape the font's position on screens <= 1600x900 resolution

	//First, this function asjusts the GUI so it's centered around the camera
	void Start()
	{
		posOfGUI = GameObject.Find("Main Camera").GetComponent<Camera>().WorldToScreenPoint(gameObject.transform.position);
	}

	//Updates the GUI as well as setting the dynamic behavior of the text.
	void OnGUI()
	{
		GUI.matrix = Matrix4x4.TRS( Vector3.zero, Quaternion.identity, new Vector3( Screen.width / 1600.0f, Screen.height / 900.0f, 1.0f ) );
		GUI.Label(new Rect(xSize,ySize,posOfGUI.x,posOfGUI.y), currMessage, fontStyle);
	}

	// Makes the text "dissapear" from the screen
	void MakeMessageDissapear()
	{
		currMessage = "";
	}

	// Changes the text to be what's displayed on the screen
	public void ChangeText(string newMessage)
	{
		currMessage = newMessage;
		if(IsInvoking("MakeMessageDissapear") == false)
			Invoke("MakeMessageDissapear",timeToDissapear);
		else
			Invoke("MakeMessageDissapear",timeToDissapear * 2);
	}

}
