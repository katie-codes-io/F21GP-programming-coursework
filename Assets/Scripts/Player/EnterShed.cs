using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterShed : MonoBehaviour
{

    //=========================================================//
    // Declare private variables
    private GameObject shedFront;
    private GameObject shedRoof;
    private GameObject[] objects = new GameObject[2];

    //=========================================================//
    // Declare lifecycle methods
    void Start()
    {
        // Get the shed front wall and roof objects
        shedFront = GameObject.Find("Front");
        shedRoof  = GameObject.Find("Roof");
        objects[0] = shedFront;
        objects[1] = shedRoof;
    }

    //=========================================================//
    // Override methods
    void OnTriggerExit(Collider other) {

        // First check if other is a player
        if (other.tag == "Player") {

            // Adjust the transparency of the front wall and roof
            foreach (GameObject obj in objects) {
                var material = obj.GetComponent<Renderer>().material;
                var color = material.color;
                
                // Switch transparency
                if (color.a == 1.0f) {
                    color.a = 0.3f;
                } else {
                    color.a = 1.0f;
                }

                // Set color with new transparency
                material.color = color;
            }
        }
    }
}
