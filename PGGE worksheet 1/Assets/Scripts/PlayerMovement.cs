using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController PlayerController;

    private float HInput, VInput;
    private float RunSpeed = 10f;
    private float SprintSpeed = 20f;
    private float JumpHeight = 10f;
    private float gravity = -5f;
    private float GroundDistance = 0.4f;

    

    private Vector3 MovementDirection, Velocity;

    public LayerMask GroundMask;


    private bool IsGrounded;
    private void Start()
    {
        PlayerController = GetComponent<CharacterController>();
     
        
          

        
    }
    private void Update()
    {
        //check if player is touching ground
        GroundChecker();

        //move player with wasd
        MovePlayer();

        //gravity effect 
        GravityEffect();

        //function to make player sprint
        SprintFunction();

        //function to make the player jump (not complete)
        //JumpFunction();

    }

    //private void JumpFunction()
    //{
    //    if (JumpInput) {
    //        PlayerController.Move(MovementDirection * JumpHeight * Time.deltaTime);
    //    }
    //}
    private void SprintFunction()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            PlayerController.Move(MovementDirection * SprintSpeed * Time.deltaTime);

        }

    }
    private void GravityEffect()
    {
        Velocity.y += gravity * Time.deltaTime;
        PlayerController.Move(Velocity * Time.deltaTime);
    }

    private void GroundChecker()
    {
        IsGrounded = Physics.CheckSphere(transform.position, GroundDistance, GroundMask);

        if (IsGrounded && Velocity.y < 0)
        {
            Velocity.y = -2.0f;
        }
    }
    
    private void MovePlayer()
    {
        HInput = Input.GetAxis("Horizontal");
        VInput = Input.GetAxis("Vertical");

        //move charactor left right back and forth 
        MovementDirection = transform.right * HInput + transform.forward * VInput;
        PlayerController.Move(MovementDirection * RunSpeed * Time.deltaTime);
    }


}
