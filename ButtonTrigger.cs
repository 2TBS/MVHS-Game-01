//SG 10/15/16
//TO DO: 1.Find max chapter number(this will prolly be decided at the end of the game)
//		 2.Implement behavior when max chapter number is reached. (Go back to chapter 1 or the "next" button disappears, etc.)
//Bugs found:
//		 1.First time the next button is clicked, chapterText doesn't change. Satrts working on 2nd click.
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ButtonTrigger : MonoBehaviour 
{
	/*chapterSelected holds the int value of the chapter that the player is choosing
		clicking the "next" button increments chapterSelected by 1 until max is reached
		
	*/
	public int chapterSelected=0;
	public Text chapterText;
	public void Start()
	{
		//chapterText = GetComponent<Text> ();
		Debug.Log ("Testing:chapterSelected is " + chapterSelected);
	}
	public void findClickedButton(string buttonPressed)
	{
		if (buttonPressed.Equals ("next")) 
		{
			chapterSelected++;
		} 
		else if (buttonPressed.Equals ("previous") && chapterSelected >= 2) 
		{
			chapterSelected--;
		} 
		else if (buttonPressed.Equals ("play")) 
		{
			//switch to appropriate scene
		}
		Debug.Log (buttonPressed + " was clicked and chapterSelected is " + chapterSelected);
		chapterText.text="Chapter " + chapterSelected + ", the blah blah"; 
	}
}
