using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBugs : MonoBehaviour
{
    public GameObject swarm;
    public float start = 1.0f;
    public float frequency = 1.0f;

    private GameObject[] grasses;

    // Start is called before the first frame update
    void Start()
    {
        // Get the position of all the grasses
        grasses = GameObject.FindGameObjectsWithTag("Grass");

        // Start spawning bugs
        Invoke("SpawnBug", start);
    }

    void SpawnBug()
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

        // Spawn the next bug
        Invoke("SpawnBug", frequency);
    }
}
