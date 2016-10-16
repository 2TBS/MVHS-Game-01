using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Canvas playCanvas;
    public Canvas optionsCanvas;
    public Canvas creditsCanvas;

    
	// Use this for initialization
	void Start () {
        playCanvas = playCanvas.GetComponentInParent<Canvas>();
        optionsCanvas = optionsCanvas.GetComponent<Canvas>();
        creditsCanvas = creditsCanvas.GetComponent<Canvas>();
    }

	// Update is called once per frame
	void Update () {
	}

  	public void OpenCredits () {
        creditsCanvas.GetComponentInParent<GameObject>().SetActive(true);
	}

	///Opens the options menu. Author: NULL
	public void OpenOptions()
    {
        optionsCanvas.GetComponentInParent<GameObject>().SetActive(true);
    }

	///Opens the play/level select menu. Author: NULL
	public void OpenPlay ()
    {
        playCanvas.GetComponentInParent<GameObject>().SetActive(true);
    }



	///Quits the game. Author: NULL
	public void Quit () {

	}
}
