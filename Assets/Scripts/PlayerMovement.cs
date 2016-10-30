#region Using Statements
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using System.Collections;
#endregion

/// <summary>
/// Methods for Control changing menu, with integrated InputManager by Ben C. 
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    #region Fields
    public const float RUN_ADDITIONAL_SPEED = 1.25f;
    public float crouchSpeedMult;
    public Pl_InputManager input;
    public float walkSpeed;

    public bool isCrouching;
    public bool running;
    #endregion

    #region Methods
    void Start()
    {
        input = input.GetComponent<Pl_InputManager>();
    }

    void Update()
    {
        Vector3 velocity = new Vector3(0, 0, 0);
	    if(input.GetKey("Run"))
        {
            if (!isCrouching)
		        running = true;
	    }
	    if(input.GetKey("Left"))
        {
            velocity.x -= walkSpeed;

            if (running && !isCrouching)
                velocity.x -= RUN_ADDITIONAL_SPEED;
            if (isCrouching)
                velocity.x *= crouchSpeedMult;
	    }
        else if(input.GetKey("Right"))
        {
            velocity.x += walkSpeed;

            if (running && !isCrouching)
                velocity.x += RUN_ADDITIONAL_SPEED;
            if (isCrouching)
                velocity.x *= crouchSpeedMult;

	    }

	    if(input.GetKey("Jump")) {
		    //do stuff
	    }
        if (input.GetKey("Crouch"))
        {
            isCrouching = true;
        }
        else
            isCrouching = false;


        // updates the position
        Vector3 position = transform.position;

        position += velocity;
    }
    #endregion
}