using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//SUMMARY: Code for the Options submenu in the Main Menu.
public class Options : MonoBehaviour {

	public Slider volume;
	public Dropdown dropdown;
	public Text volumeValue;
	public Canvas generalPanel;
	public Canvas controlsPanel;
	public Canvas optionsMenu;
	public Dropdown graphics;
	public Dropdown resolution;

	public Canvas mainMenu;
	public Button fullscreen;
	public Text fullscreenLabel;
	
	//public Controls controls;
	
	void Start () {
		
		volume = volume.GetComponent<Slider> ();
		dropdown = dropdown.GetComponent<Dropdown> ();
		volumeValue = volumeValue.GetComponent<Text> ();
		generalPanel = generalPanel.GetComponent<Canvas> ();
		controlsPanel = controlsPanel.GetComponent<Canvas> ();
		graphics = graphics.GetComponent<Dropdown> ();
		resolution = resolution.GetComponent<Dropdown> ();
		optionsMenu = optionsMenu.GetComponent<Canvas> ();
		mainMenu = mainMenu.GetComponent<Canvas> ();
		fullscreen = fullscreen.GetComponent<Button> ();
		fullscreenLabel = fullscreenLabel.GetComponent<Text> ();
		//controls = controls.GetComponent<Controls> ();

		volume.maxValue = 100;
		volume.minValue = 0;
		volume.wholeNumbers = true;

		generalPanel.transform.Rotate (20.0f, 0.0f, 0.0f);
	
	}

	void Update () {
		
		fullscreenLabel.text = (Screen.fullScreen) ? "Enabled" : "Disabled";
		if(Input.GetKey(KeyCode.F11)) fullscreenToggle();
		if(Screen.width > 1300) mainMenu.scaleFactor = 2;
		else if(Screen.width < 700) mainMenu.scaleFactor = .5f;
		else mainMenu.scaleFactor = 1;
			
		AudioListener.volume = volume.value / 100;

		volumeValue.text = volume.value.ToString ();

		//Which panel is active
		if(dropdown.value == 0 && optionsMenu.enabled) {
			generalPanel.enabled = true;
			controlsPanel.enabled = false;
		}  else if(dropdown.value == 1) {
			generalPanel.enabled = false;
			controlsPanel.enabled = true;
		}

		//Graphics setting
		switch (graphics.value) {
		case 0:
			QualitySettings.SetQualityLevel (1, true);
			break;
		case 1:
			QualitySettings.SetQualityLevel (2, true);
			break;
		case 2:
			QualitySettings.SetQualityLevel (3, true);
			break;
		case 3:
			QualitySettings.SetQualityLevel (4, true);
			break;
		case 4:
			QualitySettings.SetQualityLevel (5, true);
			break;
		case 5:
			QualitySettings.SetQualityLevel (6, true);
			break;

		}

		//Screen resolution
		switch (resolution.value) {
		case 0: //auto
			Screen.SetResolution(Screen.currentResolution.width,Screen.currentResolution.height,Screen.fullScreen);
			break;
		case 1: //1920x1200
			Screen.SetResolution(1920,1200,Screen.fullScreen);
			break;
		case 2: //1920x1080
			Screen.SetResolution(1920,1080,Screen.fullScreen);
			break;
		case 3: //1366x768
			Screen.SetResolution(1366,768,Screen.fullScreen);
			break;
		case 4: //1280x1024
			Screen.SetResolution(1280,1024,Screen.fullScreen);
			break;
		case 5: //1024x768
			Screen.SetResolution(1024,768,Screen.fullScreen);
			break;
		}
			
	}

	///when "reset to default" is pressed
	public void resetOptions() {
		if(generalPanel.enabled) {
			graphics.value = 4;
		volume.value = 50;
		resolution.value = 1;
		} else if(controlsPanel.enabled) {
			//controls.WriteDefaultControls();
		}
		
	}
	
	public void fullscreenToggle() {
		Screen.fullScreen = !Screen.fullScreen;
	}
}