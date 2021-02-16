using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour {
    
    float velocity = 2f;
    float gravity = -9.8f;
    Vector3 vector = Vector3.zero;

    Animator animator;
    CharacterController controller;

    void Start() {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update () {

        vector = Vector3.zero;

        bool moveUp    = Input.GetKey(KeyCode.UpArrow);
        bool moveDown  = Input.GetKey(KeyCode.DownArrow);
        bool moveLeft  = Input.GetKey(KeyCode.RightArrow);     // the left and right arrows are reversed due to the fixed camera
        bool moveRight = Input.GetKey(KeyCode.LeftArrow);      // the object is facing the camera rather than the camera being behind

        if (controller.isGrounded) {

            // Rotate
            if (moveUp) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.15F);
            }

            if (moveLeft) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.15F);
            }
            
            if (moveDown) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.15F);
            }

            if (moveRight) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.15F);
            }

            // Move
            if (moveDown | moveLeft | moveRight | moveUp) {
                // apply gravity
                vector.y -= gravity * velocity;
                vector = transform.TransformDirection(Vector3.forward);
                controller.SimpleMove(vector * velocity);
            }
        }

    }
}
