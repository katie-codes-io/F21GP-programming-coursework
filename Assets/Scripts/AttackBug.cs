using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBug : MonoBehaviour
{
    public float xForce = 100;
    public float yForce = 100;
    public float zForce = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    void Attack() {
        GetComponent<Rigidbody>().AddForce(xForce, yForce, zForce);
    }

}
