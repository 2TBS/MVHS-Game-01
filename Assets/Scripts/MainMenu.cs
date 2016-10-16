using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Canvas playCanvas;
    public Canvas optionsCanvas;
    public Canvas creditsCanvas;

    
	// Use this for initialization
	void Start () {
        playCanvas = playCanvas.GetComponent<Canvas>();
        optionsCanvas = optionsCanvas.GetComponent<Canvas>();
        creditsCanvas = creditsCanvas.GetComponent<Canvas>();

        playCanvas.enabled = false;
        optionsCanvas.enabled = false;
        creditsCanvas.enabled = false;
    }

	// Update is called once per frame
	void Update () {
	}

    ///Opens the credits menu. Author: Henry
    public void OpenCredits () {
        creditsCanvas.enabled = true;
	}

	///Opens the options menu. Author: Henry
	public void OpenOptions()
    {
        optionsCanvas.enabled = true;
    }

	///Opens the play/level select menu. Author: Henry
	public void OpenPlay ()
    {
        playCanvas.enabled = true;
    }



	///Quits the game. Author: Henry
	public void Quit () {
        Application.Quit();
	}
}
