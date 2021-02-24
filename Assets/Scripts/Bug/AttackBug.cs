using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class AttackBug : MonoBehaviour
{
    //=========================================================//
    // Declare public variables
    public float xForce = 100;
    public float yForce = 100;
    public float zForce = 100;

    //=========================================================//
    // Declare private variables
    private AudioSource audioSource;
    private NavMeshAgent agent;
    private bool wasAttacked = false;
    private bool wasKilled   = false;
    private float elapsed    = 0.0f;
    private float wait       = 2.0f;

    //=========================================================//
    // Declare lifecycle methods
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check if the bug was killed
        if (wasKilled) {

            // Wait a little time before destroying the object
            elapsed += Time.deltaTime;
            if (elapsed >= wait) {
                Destroy(gameObject);
            }
        }
    }

    //=========================================================//
    // Declare private methods

    // Attack bug
    private void Attack() {
        wasAttacked = true;
        
        // Play sound effect
        audioSource.Play();

        // Apply force
        GetComponent<Rigidbody>().AddForce(xForce, yForce, zForce);
    }

    //=========================================================//
    // Override methods

    // Collider with player
    void OnTriggerStay (Collider other) {

        // First check if other is a player
        if (other.tag == "Player") {

            // Check if player is attacking
            var controller = other.GetComponent<KeyboardController>();
            bool attacking = Input.GetKey(controller.keyAttack);

            if (attacking) {
                Attack();
            }
        }
    }

    // Collision with the ground
    void OnCollisionEnter (Collision collision) {

        // Check if bug has been attacked first
        if (wasAttacked) {

            // Check if collision is with terrain, then kill bug
            string[] obstacles = {"Terrain", "Wall"};
            if (obstacles.Contains(collision.collider.name)) {
                wasKilled = true;
                
                // Update the number of bugs killed
                int current = PlayerStats.GetBugs();
                PlayerStats.SetBugs(current + 1);
            }
        }
    }
}
