using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("Print Statement!");
	}

	// Update is called once per frame
	void Update () {

	}

	public void HeyThatsPrettyGood(string saying)
	{
	  Debug.Log("Hey thats pretty "+saying);
	}

  	public void OpenCredits () {

	}

	///Opens the options menu. Author: NULL
	public void OpenOptions() {

	}

	///Opens the play/level select menu. Author: NULL
	public void OpenPlay () {

	}



	///Quits the game. Author: NULL
	public void Quit () {

	}
}
