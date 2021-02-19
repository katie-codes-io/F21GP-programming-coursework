using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BugNav : MonoBehaviour
{
    private GameObject[] sunflowers = new GameObject[9];
    private GameObject sunflower;

    // Start is called before the first frame update
    void Start()
    {
        // Get all sunflowers
        sunflowers = GameObject.FindGameObjectsWithTag("Sunflower");

        // Pick a random sunflower
        System.Random random = new System.Random();
        int index = random.Next(sunflowers.Length);
        sunflower = sunflowers[index];

        // Use NavMeshAgent to navigate bug to sunflower
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = sunflower.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
