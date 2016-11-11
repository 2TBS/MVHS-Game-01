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
    [SerializeField]
    #region Fields
    public const float RUN_ADDITIONAL_SPEED = 1.25f;
    public float crouchSpeedMult;
    public Pl_InputManager input;
    public CharacterController controller;
    public float walkSpeed;

    public bool isCrouching;
    public bool running;

    public Vector3 velocity;


    #endregion

    #region Methods
    void Start()
    {
        input = GetComponentInParent<Pl_InputManager>();
        controller = GetComponentInParent<CharacterController>();
        velocity = new Vector3(0, 0, 0);
    }

    void FixedUpdate()
    {

    }

    void Update()
    {
        if (input.GetKey("Run"))
        {
            if (!isCrouching)
                running = true;
        }
        else running = false;

        if (Input.GetKey(input.Left))
        {
            velocity.x -= walkSpeed;

            if (running && !isCrouching)
                velocity.x -= RUN_ADDITIONAL_SPEED;
            if (isCrouching)
                velocity.x *= crouchSpeedMult;
        }
        else if (input.GetKey("Right"))
        {
            velocity.x += walkSpeed;

            if (running && !isCrouching)
                velocity.x += RUN_ADDITIONAL_SPEED;
            if (isCrouching)
                velocity.x *= crouchSpeedMult;

        }

        if (input.GetKey("Jump"))
        {

        }
        if (input.GetKey("Crouch"))
        {
            isCrouching = true;
        }
        else
            isCrouching = false;


        // updates the position
        controller.Move(velocity);
        velocity = new Vector3(0, velocity.y, 0);


        //gravity
        if (!controller.isGrounded)
            velocity.y -= Time.deltaTime * 2;

    }


    #endregion
}