using UnityEngine;
using System.Collections;

public class GenericScene : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	///Causes events to occur when player hits certain triggers
	public void OnTriggerEnter(Collider col)
	{
		if(col.tag == "decision") {
			//stuff happens
		} else if(col.tag == "dialogue") {
			//stuff happens
		}
	}
}
