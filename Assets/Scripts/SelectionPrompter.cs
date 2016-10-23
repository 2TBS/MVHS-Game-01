using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectionPrompter : MonoBehaviour {
//Create the 4 buttons


	// Use this for initialization
	void Start () {
		//Init 4 buttons
	}
	
	// Update is called once per frame
	void Update () {
	//Do nothing here
	}

	public void ShowButtons (String button1Text, String button2Text, String button3Text, String button4Text) {
		//Enable the four buttons, and wait for a response
	}

	public int GetButtonPressed (int buttonNumber)
	{
		//basically just returns the button that was pressed for further parsing
		return buttonNumber;
	}
}
