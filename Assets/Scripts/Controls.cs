using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using System.Collections;

///Methods for Control changing menu, with integrated InputManager by Ben C. 
public class Controls : MonoBehaviour {

//List of editable controls

public KeyCode Left; //3
public KeyCode Right; //4
public KeyCode Jump; //5
public KeyCode Run; //6
public KeyCode Crouch;

private KeyCode[] controlList;
private Text[] textList;

private String configPath; 
string[] defaultControls = {"W","S","A","D","Space","LeftShift"};
public Text infoText;

Event currentEvent;
	// Use this for initialization
	void Start () {
		configPath = Application.dataPath + "/controls.cfg";
		controlList = new KeyCode[] {Forward, Back, Left, Right, Jump, Run};
		textList = new Text[] {
		GameObject.Find("Forward").GetComponent<Text> (),
		GameObject.Find("Back").GetComponent<Text> (),
		GameObject.Find("Left").GetComponent<Text> (),
		GameObject.Find("Right").GetComponent<Text> (),
		GameObject.Find("Jump").GetComponent<Text> (),
		GameObject.Find("Run").GetComponent<Text> ()
		};
		
		infoText = infoText.GetComponent<Text> ();
		infoText.enabled = false;
		
		
			if(File.Exists(configPath) && ControlsValid())  {
			Debug.Log("Successfully loaded controls file");
			} else {
			Debug.Log("Controls file is nonexistent or corrupted. Generating new one...");
			using (var writer = new StreamWriter(File.Create(configPath))) {}
			WriteDefaultControls();
		
		}	
		ReloadControls();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI () {
	currentEvent = Event.current;
	}
	
	public KeyCode GetKey (int id) {
		string[] lines = File.ReadAllLines(configPath);
		return (KeyCode)System.Enum.Parse(typeof(KeyCode), lines[id-1]);
	}
	
	//input detection mode
	public void SetKey (int id) {
		
			Text buttonText = textList[id-1];
			Debug.Log("Selecting Key " + id);
			infoText.enabled = true;
			StartCoroutine(WaitForKey(id));
	}
	 IEnumerator WaitForKey (int id) {
	
			Text buttonText = textList[id-1];
			while(true) {
				if(currentEvent != null && (currentEvent.isKey || currentEvent.isMouse)) {
				if (currentEvent.keyCode == KeyCode.Backspace) {
					   buttonText.text = GetKey(id).ToString();
					   infoText.enabled = false;
					   Debug.Log("Key Selection cancelled");
					  yield break;
				 } else if(currentEvent.keyCode != KeyCode.Backspace && currentEvent.keyCode != KeyCode.None) {
					 buttonText.text = currentEvent.keyCode.ToString();
					 Debug.Log("Key Selection successful");
					 string[] arrLine = File.ReadAllLines(configPath);
     				arrLine[id - 1] = buttonText.text;
     				File.WriteAllLines(configPath, arrLine);
		 			Debug.Log("Set key " + id + " to " + buttonText.text);
					infoText.enabled = false;
					ReloadControls();
					yield break;
				 } else yield return null;
			} else yield return null;
			
			
			} 
		}
		
	
	public void WriteDefaultControls () {
		Debug.Log("Writing default controls...");
		File.WriteAllLines(configPath, defaultControls);
		ReloadControls();
	}
	
	public void ReloadControls () {
		for(int i = 0; i < controlList.Length; i++) {
			controlList[i] = GetKey(i+1);
			textList[i].text = GetKey(i+1).ToString();
		}
		
		Debug.Log("Successfully reloaded controls");
	}
	
	protected bool ControlsValid () {
		try {
			ReloadControls();
			return true;
		} catch {
			return false;
		}
	}
}
