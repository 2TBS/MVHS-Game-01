using UnityEngine;
using System;
using System.IO;

/// <summary> Custom InputManager by dbqeo </summary>
public class Pl_InputManager : Controls {

//List of editable controls
[SerializeField]

private KeyCode[] controlList;
private string[] controlListNames;
private String configPath; 

string[] defaultControls = {"W","S","A","D","Space","LeftShift"};

string[] axes = {"Vertical","Horizontal"};

Event currentEvent;
	// Use this for initialization
	void Start () {

		configPath = Application.dataPath + "/controls.cfg";
		controlListNames = new string[] {"Forward","Back","Left","Right","Jump","Run"};
		controlList = new KeyCode[] {Forward, Back, Left, Right, Jump, Run};
		
			if(File.Exists(configPath) && ControlsValid())  {
				ReloadControls();
			} else {
			Debug.Log("Controls file is nonexistent or corrupted. Generating new one...");
			using (var writer = new StreamWriter(File.Create(configPath))) {}
			WriteDefaultControls();
			ReloadControls();
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

	public KeyCode Key (int id) {
		string[] lines = File.ReadAllLines(configPath);
		return (KeyCode)System.Enum.Parse(typeof(KeyCode), lines[id-1]);
	}

	public bool GetKey (String keyName) {
		return Input.GetKey(Key(keyName));
	}
}
