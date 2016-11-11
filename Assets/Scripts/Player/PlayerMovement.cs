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

    //number of seconds to move upwards
    public float JUMP_LIMIT = 0.5f;
    public float JUMP_SPEED = 0.9f;
    public float CROUCH_SPEED_MULT = 0.5f;
    public float WALK_SPEED = 1f;
    
    public Pl_InputManager input;
    public CharacterController controller;
   

    private bool isCrouching;
    private bool running;
    public bool jumping;

    //The relative velocity of the player
    public Vector3 velocity;

    public float timer;

    #endregion

    #region Methods
    void Start()
    {
        timer = 0;
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
            velocity.x -= WALK_SPEED;

            if (running && !isCrouching)
                velocity.x -= RUN_ADDITIONAL_SPEED;
            if (isCrouching)
                velocity.x *= CROUCH_SPEED_MULT;
        }
        else if (input.GetKey("Right"))
        {
            velocity.x += WALK_SPEED;

            if (running && !isCrouching)
                velocity.x += RUN_ADDITIONAL_SPEED;
            if (isCrouching)
                velocity.x *= CROUCH_SPEED_MULT;

        }

        if (input.GetKeyDown("Jump") && !jumping)
        {
            
            jumping = true;
            while(jumping)
                if(timer < JUMP_LIMIT && velocity.y >= -0.07)
                {
                    
                    velocity.y += Mathf.Sin(Mathf.PI * JUMP_SPEED);
                    timer += JUMP_LIMIT / 2;
                }
                else {
                    jumping = false;
                    timer = 0;
                }
              
            
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
        if (!controller.isGrounded && !jumping)
            velocity.y -= Time.deltaTime * 2;
        else if (!jumping) velocity.y = 0;

    }


    #endregion
}