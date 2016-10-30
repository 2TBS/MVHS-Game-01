using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using System.Collections;

///Methods for Control changing menu, with integrated InputManager by Ben C. 
public class PlayerMovement : MonoBehaviour {

public Pl_InputManager input;

void Start() {

	input = input.GetComponent<Pl_InputManager> ();
}

void Update() {

	if(input.GetKey("Forward")) {
		//do stuff
	} else if(input.GetKey("Back")) {
		//do stuff
	}

	if(input.GetKey("Jump")) {
		//do stuff
	} else if(input.GetKey("Crouch")) {
		//do stuff
	}
}
}