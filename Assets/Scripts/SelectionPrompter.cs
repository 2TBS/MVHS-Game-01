using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectionPrompter : MonoBehaviour 
{
//Create the 4 buttons
	public Button buttonOne;
	public Button buttonTwo;
	public Button buttonThree;
	public Button buttonFour;

	// Use this for initialization
	void Start () 
	{
		
		//Init 4 buttons
	}
	public void ShowButtons (int numButtons)
	{
		if (numButtons == 4) 
		{
			buttonOne.gameObject.SetActive(true);
			buttonTwo.gameObject.SetActive(true);
			buttonThree.gameObject.SetActive(true);
			buttonFour.gameObject.SetActive(true);
		} 
		else if (numButtons == 3) 
		{
			buttonOne.gameObject.SetActive(true);
			buttonTwo.gameObject.SetActive(true);
			buttonThree.gameObject.SetActive(true);
		} 
		else if (numButtons == 2) 
		{
			buttonOne.gameObject.SetActive(true);
			buttonTwo.gameObject.SetActive(true);
		}
		//Enable the four buttons, and wait for a response
	}

	public int GetButtonPressed (int buttonNumber)
	{
		//basically just returns the button that was pressed for further parsing
		return buttonNumber;
	}
}
