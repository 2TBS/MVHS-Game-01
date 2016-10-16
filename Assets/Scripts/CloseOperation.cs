using UnityEngine;
using System.Collections;

public class CloseOperation : MonoBehaviour {

    public Canvas play;
    public Canvas credits;
    public Canvas options;
	// Use this for initialization
	void Start () {
        play = play.GetComponent<Canvas>();
        credits = credits.GetComponent<Canvas>();
        options = options.GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// Closes all the canvas besides the home screen. Author: Henry
    public void CloseMenu()
    {
        play.enabled = false;
        credits.enabled = false;
        options.enabled = false;
        Debug.Log("Closed menus");
    }
}
