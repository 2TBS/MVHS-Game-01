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
    public Controls input;
    public float walkSpeed;

    public bool isCrouching;
    public bool running;
    #endregion

    #region Methods
    void Start()
    {
        input = input.GetComponent<Controls>();
    }

    void Update()
    {
        Vector3 velocity = new Vector3(0, 0, 0);
	    if(Input.GetKey(input.Run))
        {
            if (!isCrouching)
		        running = true;
	    }
	    if(Input.GetKey(input.Left))
        {
            velocity.x -= walkSpeed;

            if (running && !isCrouching)
                velocity.x -= RUN_ADDITIONAL_SPEED;
            if (isCrouching)
                velocity.x *= crouchSpeedMult;
	    }
        else if(Input.GetKey(input.Right))
        {
            velocity.x += walkSpeed;

            if (running && !isCrouching)
                velocity.x += RUN_ADDITIONAL_SPEED;
            if (isCrouching)
                velocity.x *= crouchSpeedMult;

	    }

	    if(Input.GetKey(input.Jump)) {
		    //do stuff
	    }
        if (Input.GetKey(input.Crouch))
        {
            isCrouching = true;
        }
        else
            isCrouching = false;


        // updates the position
        Vector3 position = transform.position;

        position += velocity;

        transform.position = position;
    }
    #endregion
}