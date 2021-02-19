using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBugs : MonoBehaviour
{
    public GameObject bug;
    public float start = 1.0f;
    public float frequency = 1.0f;

    private GameObject[] grasses;

    // Start is called before the first frame update
    void Start()
    {
        // get the position of all the grasses
        grasses = GameObject.FindGameObjectsWithTag("Grass");

        // start spawning bugs
        Invoke("SpawnBug", start);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnBug()
    {
        // get the position of a random grass to have a bug spawn out of
        System.Random random = new System.Random();
        int index = random.Next(grasses.Length);
        GameObject grass = grasses[index];

        Vector3 spawnPoint = grass.transform.position;
        spawnPoint.y = 0.1f;

        // create the bug game object
        Instantiate(bug, spawnPoint, Quaternion.identity);

        // spawn the next bug
        Invoke("SpawnBug", frequency);
    }
}
