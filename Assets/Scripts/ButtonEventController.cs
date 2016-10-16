//SG 10/15/16
//TO DO: 1.Find max chapter number(this will prolly be decided at the end of the game)
//		 2.Implement behavior when max chapter number is reached. (Go back to chapter 1 or the "next" button disappears, etc.)
//Bugs found:
//		 FIXED 1.First time the next button is clicked, chapterText doesn't change. Satrts working on 2nd click.
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class ButtonEventController : MonoBehaviour
{
	/*chapterSelected holds the int value of the chapter that the player is choosing
		clicking the "next" button increments chapterSelected by 1 until max is reached

	*/
	public int chapterSelected;
	public Text chapterText;

    /// <summary>
    /// Holds the chapter preview images that correspond to the selected chapter.
    /// </summary>
    public Texture2D[] chapterImage;

    /// <summary>
    /// Properties of the chapter images.
    /// </summary>
    public Vector2 imagePosition, imageSize;

    /// <summary>
    /// The maximum amount of chapters
    /// </summary>
    public int maxChapters;

    /// <summary>
    /// Performs initialization on the controller
    /// </summary>
	public void Start()
	{
        // for now lets assume we have 2 chapters
        maxChapters = 2;
		//chapterText = GetComponent<Text> ();
		chapterSelected=1;

        // initializes the list of images
        chapterImage = new Texture2D[maxChapters];
        for (int i = 0; i < chapterImage.Length; i++)
        {
            // loads the file(s) and converts to bytes
            byte[] data = File.ReadAllBytes(@"Textures/Chapter" + i + ".png");

            chapterImage[i] = new Texture2D(600, 480);
            chapterImage[i].LoadImage(data);
        }
        

		Debug.Log ("Testing:chapterSelected is " + chapterSelected);
	}

    /// <summary>
    /// Takes in the name of the button that was pressed and decides what to do
    /// with it.
    /// </summary>
    /// <param name="buttonPressed">Name of the button that was pressed.</param>
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
		else if (buttonPressed.Equals ("exit")) 
		{
			//switch to aapropriate 
		}
		Debug.Log (buttonPressed + " was clicked and chapterSelected is " + chapterSelected);
		chapterText.text="Chapter " + chapterSelected + ", the blah blah";
        
	}

    /// <summary>
    /// Returns the current chapter's corresponding image.
    /// </summary>
    /// <returns>The texture of the current chapter.</returns>
    public Texture2D getCurrentChapterImage()
    {
        return chapterImage[chapterSelected];
    }
}

