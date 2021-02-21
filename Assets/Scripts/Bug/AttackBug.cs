using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackBug : MonoBehaviour
{
    public float xForce = 100;
    public float yForce = 100;
    public float zForce = 100;

    private NavMeshAgent agent;
    private bool wasAttacked = false;
    private bool wasKilled   = false;
    private float elapsed    = 0.0f;
    private float wait       = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

    // Attack bug
    void Attack() {
        wasAttacked = true;

        // Apply force
        GetComponent<Rigidbody>().AddForce(xForce, yForce, zForce);
    }

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
            if (collision.collider.name == "Terrain") {
                wasKilled = true;
                
                // Update the number of bugs killed
                int current = PlayerStats.GetBugs();
                PlayerStats.SetBugs(current + 1);
            }
        }
    }
}
