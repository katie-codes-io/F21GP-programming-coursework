using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatNav : MonoBehaviour
{
    private GameObject[] sunflowers = new GameObject[9];
    private GameObject sunflower;
    NavMeshAgent agent;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Get all sunflowers
        sunflowers = GameObject.FindGameObjectsWithTag("Sunflower");

        // Pick a random sunflower
        System.Random random = new System.Random();
        int index = random.Next(sunflowers.Length);
        sunflower = sunflowers[index];

        // Use NavMeshAgent to navigate cat
        agent = GetComponent<NavMeshAgent>();
        agent.destination = sunflower.transform.position;

        // Get the animator
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody body = GetComponent<Rigidbody>();

        Debug.Log(body.velocity.magnitude);
        if (body.velocity.magnitude > 0.0f) {
            Debug.Log("Moving");
            animator.SetBool("Walking", true);
        } else {
            animator.SetBool("Walking", false);
        }
    }
}
