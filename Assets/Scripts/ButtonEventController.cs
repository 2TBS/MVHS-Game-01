//SG 10/15/16
//TO DO: 1.Find max chapter number(this will prolly be decided at the end of the game)
//		 2.Implement behavior when max chapter number is reached. (Go back to chapter 1 or the "next" button disappears, etc.)
//		 (2 is basically done, button is locked and grayed out, cant be licked when macChappter is reached)
//		 3.Make code more elegant looking. Put nested if's into a seperate function.
//Bugs found:
//		 FIXED 1.First time the next button is clicked, chapterText doesn't change. Satrts working on 2nd click.
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ButtonEventController : MonoBehaviour
{
	/*chapterSelected holds the int value of the chapter that the player is choosing
		clicking the "next" button increments chapterSelected by 1 until max is reached

	*/
	public int chapterSelected;
	public int maxChapter;
	public Text chapterText;
	public Button nextButton;

	public void Start()
	{
		chapterSelected=1;
		maxChapter = 6; //6 is a random value I chose. Only for testing purposes can be changed to anything else.
		Debug.Log ("Testing:chapterSelected is " + chapterSelected);
	}
	public void findClickedButton(string buttonPressed)
	{
		if (buttonPressed.Equals ("next")) 
		{
			chapterSelected++;
			if (chapterSelected == maxChapter) 	//not elegant code but whatever for now
			{
				nextButton.interactable = false;//lock button
			}
		} 
		else if (buttonPressed.Equals ("previous") && chapterSelected >= 2) 
		{
			if (chapterSelected == maxChapter) 	//not elegant code but whatever for now
			{
				nextButton.interactable = true;//lock button
			}
			chapterSelected--;
		} 
		else if (buttonPressed.Equals ("play")) 
		{
			//switch to appropriate scene
		} 
		else if (buttonPressed.Equals ("exit")) 
		{
			//switch to aapropriate 
		}
		Debug.Log (buttonPressed + " was clicked and chapterSelected is " + chapterSelected);
		chapterText.text="Chapter " + chapterSelected + ", the blah blah";
	}

}

