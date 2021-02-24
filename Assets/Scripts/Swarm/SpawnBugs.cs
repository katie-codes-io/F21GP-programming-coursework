using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBugs : MonoBehaviour
{
    //=========================================================//
    // Declare public variables
    public GameObject swarm;
    public float start = 1.0f;
    public float frequency = 1.0f;

    //=========================================================//
    // Declare private variables
    private GameObject[] grasses;

    //=========================================================//
    // Declare lifecycle methods
    void Awake() {
        // Get the position of all the grasses
        grasses = GameObject.FindGameObjectsWithTag("Grass");
    }

    void Start()
    {
        // Start spawning bugs
        Invoke("Spawn", start);
    }

    //=========================================================//
    // Declare private methods
    private void Spawn()
    {
        // Get the position of a random grass to have a bug spawn out of
        System.Random random = new System.Random();
        int index = random.Next(grasses.Length);
        GameObject grass = grasses[index];

        // Set the spawn point according to grass position
        Vector3 spawnPoint = grass.transform.position;
        spawnPoint.y = 0.1f;

        // Create the swarm game object
        Instantiate(swarm, spawnPoint, Quaternion.identity);

        // Spawn the next swarm
        Invoke("Spawn", frequency);
    }
}
