using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Collections;

public class SetControls : Pl_InputManager {

//Array containing the text displays in controls assign menu
public Text[] textList;
//Text that displays message when in controls assign mode
public Text infoText;

	// Use this for initialization
	void Start () {
		infoText = infoText.GetComponent<Text> ();
		infoText.enabled = false;
	}
	void OnGUI () {
	currentEvent = Event.current;
	}
	
	///begins input detection mode
	public void SetKey (int id) {
		
			Text buttonText = textList[id-1];
			Debug.Log("Selecting Key " + id);
			infoText.enabled = true;
			StartCoroutine(WaitForKey(id));
	}

	private void ReloadControls () {
		for(int i = 0; i < controlList.Length; i++) {
			controlList[i] = GetKeyInternal(i+1);
			textList[i].text = GetKeyInternal(i+1).ToString();
		}
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
}
