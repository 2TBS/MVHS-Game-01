﻿using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using System.Collections;

///Methods for Control changing menu, with integrated InputManager by Ben C. 
public class Pl_InputManager : MonoBehaviour {

//List of editable controls
public KeyCode Left, Right, Jump, Run, Crouch;

//Array containing the above keyCodes
protected KeyCode[] controlList;

//Array containing the text displays in controls assign menu
protected Text[] textList;

//Array containing the display names for above keyCodes
protected string[] controlListNames;

//Dynamic path to controls.cfg
protected String configPath; 

//Default assigned controls
string[] defaultControls = {"A","D","Space","LeftShift", "S"};
string[] axes = {"Vertical","Horizontal"};

//Text that displays message when in controls assign mode
public Text infoText;


Event currentEvent;
	// Use this for initialization
	void Start () {
		controlListNames = new string[] {"Left","Right","Jump","Run", "Crouch"};
		configPath = Application.dataPath + "/controls.cfg";
		controlList = new KeyCode[] {Left, Right, Jump, Run, Crouch};
		
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
	
	///reads key from controls.cfg
	public KeyCode GetKeyInternal (int id) {
		string[] lines = File.ReadAllLines(configPath);
		return (KeyCode)System.Enum.Parse(typeof(KeyCode), lines[id-1]);
	}

	///overload of GetKey, intended for external use
	public bool GetKey (string id) {
		return Input.GetKey(Key(id));
	}
	
	///begins input detection mode
	public void SetKey (int id) {
		
			Text buttonText = textList[id-1];
			Debug.Log("Selecting Key " + id);
			infoText.enabled = true;
			StartCoroutine(WaitForKey(id));
	}

	///While key is being set: Waits for a valid input
	 IEnumerator WaitForKey (int id) {
	
			Text buttonText = textList[id-1];
			while(true) {
				if(currentEvent != null && (currentEvent.isKey || currentEvent.isMouse)) {
				if (currentEvent.keyCode == KeyCode.Backspace) {
					   buttonText.text = GetKeyInternal(id).ToString();
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
			controlList[i] = GetKeyInternal(i+1);
			textList[i].text = GetKeyInternal(i+1).ToString();
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

	///<summary> Gets the value being outputted by a certain axis </summary>
	public float GetAxis (String axis) {
		if(axis == "Horizontal") {
			if(Input.GetKey(Key("Forward"))) return 1;
			else if (Input.GetKey(Key("Back"))) return -1;
			else return 0;
		} else if(axis == "Vertical") {
			if(Input.GetKey(Key("Left"))) return 1;
			else if (Input.GetKey(Key("Right"))) return -1;
			else return 0;
		} else throw new System.ArgumentException("Invalid axis name");
	}

	///<summary> Gets the keycode associated with custom key names </summary>
	public KeyCode Key (String keyName) {
		for(int i = 0; i < controlListNames.Length; i++) {
			if(keyName == controlListNames[i]) return Key(i+1);
		}
		throw new System.ArgumentException("Invalid key name");
	}

	///Raw key method that accepts an integer id
	public KeyCode Key (int id) {
		string[] lines = File.ReadAllLines(configPath);
		return (KeyCode)System.Enum.Parse(typeof(KeyCode), lines[id-1]);
	}

	

}
