using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController PlayerController;
    private float HInput, VInput;
    private bool JumpInput,SprintInput;
    private float RunSpeed, JumpHeight,SprintSpeed, gravity;
    private Vector3 MovementDirection, Velocity;
    private void Start()
    {
        PlayerController = GetComponent<CharacterController>();
        RunSpeed = 12f;
        SprintSpeed = 24f;
        JumpHeight = 10f;
        gravity = -5f;   
        JumpInput = Input.GetKeyDown(KeyCode.Space);
        SprintInput = Input.GetKeyDown(KeyCode.LeftShift);
    }
    private void Update()
    {
        HInput = Input.GetAxis("Horizontal");
        VInput = Input.GetAxis("Vertical");
        
        //move charactor left right back and forth 
        MovementDirection = transform.right * HInput + transform.forward * VInput;
        PlayerController.Move(MovementDirection * RunSpeed * Time.deltaTime);

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
}
