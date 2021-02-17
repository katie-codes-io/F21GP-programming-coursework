using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour {
    
    float velocity = 2f;
    float gravity  = -9.8f;
    Vector3 vector = Vector3.zero;

    Animator animator;
    CharacterController controller;

    void Start() {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update () {

        vector = Vector3.zero;

        bool keyUp    = Input.GetKey(KeyCode.UpArrow);
        bool keyDown  = Input.GetKey(KeyCode.DownArrow);
        bool keyLeft  = Input.GetKey(KeyCode.RightArrow);     // the left and right arrows are reversed due to the fixed camera,
        bool keyRight = Input.GetKey(KeyCode.LeftArrow);      // the object is facing the camera rather than the camera being behind
        bool keyShift = Input.GetKeyDown(KeyCode.LeftShift);
        bool keySpace = Input.GetKeyDown(KeyCode.Space);

        if (controller.isGrounded) {

            // Rotate
            if (keyUp) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.15F);
            }

            if (keyLeft) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.15F);
            }
            
            if (keyDown) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.15F);
            }

            if (keyRight) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.15F);
            }

            // Moving
            if (keyDown | keyLeft | keyRight | keyUp) {
                // Check if shift button is pressed for sprinting
                if (keyShift) {
                    // Sprint animation
                    animator.SetFloat("Run Blend", 1.5f);
                } else {
                    // Walk animation
                    animator.SetFloat("Run Blend", 0.5f);
                }
                // apply gravity
                vector.y -= gravity * velocity;
                vector = transform.TransformDirection(Vector3.forward);
                controller.SimpleMove(vector * velocity);
            }

            // Stopped moving
            if (!keyDown & !keyLeft & !keyRight & !keyUp) {
                // Idle animation
                animator.SetFloat("Run Blend", 0.0f);
            }
        
            // Attacking
            if (keySpace) {
                // Attack animation
                animator.SetBool("Attack", true);
            }

            // Stopped attacking
            if (!keySpace) {
                // Attack animation
                animator.SetBool("Attack", false);
            }
            
        }

    }
}
