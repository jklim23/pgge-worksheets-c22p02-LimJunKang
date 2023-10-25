using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController PlayerController;

    private float HInput, VInput;
    private float RunSpeed = 12f;
    private float JumpHeight = 10f;
    private float SprintSpeed = 24f;
    private float gravity = -5f;
    private float GroundDistance = 0.4f;

    

    private Vector3 MovementDirection, Velocity;
    public Transform GroundCheck;
    public LayerMask GroundMask;

    private bool JumpInput, SprintInput;
    private bool IsGrounded;
    private void Start()
    {
        PlayerController = GetComponent<CharacterController>();
     
        
          

        JumpInput = Input.GetKeyDown(KeyCode.Space);
        SprintInput = Input.GetKeyDown(KeyCode.LeftShift);
    }
    private void Update()
    {
        IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        HInput = Input.GetAxis("Horizontal");
        VInput = Input.GetAxis("Vertical");
        
        //move charactor left right back and forth 
        MovementDirection = transform.right * HInput + transform.forward * VInput; 
        if (SprintInput)
        {
            PlayerController.Move(MovementDirection * SprintSpeed * Time.deltaTime);

        }
        else
        {
            PlayerController.Move(MovementDirection * RunSpeed * Time.deltaTime);

        }
       

        //gravity effect 
        Velocity.y += gravity * Time.deltaTime;
        PlayerController.Move(Velocity  * Time.deltaTime);

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
        
    }
}
