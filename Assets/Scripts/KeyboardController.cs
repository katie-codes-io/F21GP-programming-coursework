using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour {
    
    float velocity = 2f;
    float gravity  = -9.8f;
    Vector3 vector = Vector3.zero;

    Animator animator;
    CharacterController controller;

    public KeyCode keyUp     = KeyCode.W;
    public KeyCode keyDown   = KeyCode.S;
    public KeyCode keyLeft   = KeyCode.A;
    public KeyCode keyRight  = KeyCode.D;
    public KeyCode keySprint = KeyCode.LeftShift;
    public KeyCode keyAttack = KeyCode.Space;
    public KeyCode keyPickup = KeyCode.E;

    void Start() {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update () {

        vector = Vector3.zero;

        bool pressingUp     = Input.GetKey(keyUp);
        bool pressingDown   = Input.GetKey(keyDown);
        bool pressingLeft   = Input.GetKey(keyRight);     // the left and right arrows are reversed due to the fixed camera,
        bool pressingRight  = Input.GetKey(keyLeft);      // the object is facing the camera rather than the camera being behind
        bool pressingShift  = Input.GetKeyDown(keySprint);
        bool pressingSpace  = Input.GetKeyDown(keyAttack);

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
                // apply gravity
                vector.y -= gravity * velocity;
                vector = transform.TransformDirection(Vector3.forward);
                controller.SimpleMove(vector * velocity);
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
