using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using System.Collections;

///Methods for Control changing menu, with integrated InputManager by Ben C. 
public class PlayerMovement : MonoBehaviour {

public Pl_InputManager input;
public float walkSpeed;
public bool running;

void Start() {

	input = input.GetComponent<Pl_InputManager> ();
}

void Update() {

	if(input.GetKey("Run")) {
		running = true;
	}
	if(input.GetKey("Left")) {
		if(running) 
			/*stuff*/;
		else /*stuff*/;

	} else if(input.GetKey("Right")) {
		if(running) 
			/*stuff*/;
		else /*stuff*/;
	}

	if(input.GetKey("Jump")) {
		//do stuff
	} else if(input.GetKey("Crouch")) {
		//do stuff
	}
}
}