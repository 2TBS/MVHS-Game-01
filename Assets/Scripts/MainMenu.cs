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
    }

	// Update is called once per frame
	void Update () {
	}

  	public void OpenCredits () {
        optionsCanvas.enabled = true;
        //creditsCanvas.GetComponentInParent<GameObject>().SetActive(true);
	}

	///Opens the options menu. Author: NULL
	public void OpenOptions()
    {
        optionsCanvas.enabled = true;
        //optionsCanvas.GetComponentInParent<GameObject>().SetActive(true);
    }

	///Opens the play/level select menu. Author: NULL
	public void OpenPlay ()
    {
        playCanvas.enabled = true;
        //playCanvas.GetComponentInParent<GameObject>().SetActive(true);
    }



	///Quits the game. Author: NULL
	public void Quit () {

	}
}
