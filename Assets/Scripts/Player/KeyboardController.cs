﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour {
    
    //=========================================================//
    // Declare public variables
    public KeyCode keyUp     = KeyCode.W;
    public KeyCode keyDown   = KeyCode.S;
    public KeyCode keyLeft   = KeyCode.A;
    public KeyCode keyRight  = KeyCode.D;
    public KeyCode keySprint = KeyCode.LeftShift;
    public KeyCode keyAttack = KeyCode.Space;
    public KeyCode keyPickup = KeyCode.E;

    //=========================================================//
    // Declare private variables
    private Animator animator;
    private CharacterController controller;

    //=========================================================//
    // Declare lifecycle methods

    void Awake() {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update () {

        // Get keyboard input
        bool pressingUp     = Input.GetKey(keyUp);
        bool pressingDown   = Input.GetKey(keyDown);
        bool pressingLeft   = Input.GetKey(keyRight);     // the left and right arrows are reversed due to the fixed camera,
        bool pressingRight  = Input.GetKey(keyLeft);      // the object is facing the camera rather than the camera being behind
        bool pressingShift  = Input.GetKeyDown(keySprint);
        bool pressingSpace  = Input.GetKeyDown(keyAttack);

        // Start transforming the player
        if (controller.isGrounded) {

            // Rotate
            if (pressingUp) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.15F);
            }

            if (pressingLeft) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.15F);
            }
            
            if (pressingDown) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.15F);
            }

            if (pressingRight) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.15F);
            }

            // Moving
            if (pressingDown | pressingLeft | pressingRight | pressingUp) {
                // Check if shift button is pressed for sprinting
                if (pressingShift) {
                    // Sprint animation
                    animator.SetFloat("Run Blend", 1.5f);
                } else {
                    // Walk animation
                    animator.SetFloat("Run Blend", 0.5f);
                }
            }

            // Stopped moving
            if (!pressingDown & !pressingLeft & !pressingRight & !pressingUp) {
                // Idle animation
                animator.SetFloat("Run Blend", 0.0f);
            }
        
            // Attacking
            if (pressingSpace) {
                // Attack animation
                animator.SetBool("Attack", true);
            }

            // Stopped attacking
            if (!pressingSpace) {
                // Attack animation
                animator.SetBool("Attack", false);
            }
            
        }

    }
}
