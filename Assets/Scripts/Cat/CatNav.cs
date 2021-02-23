using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatNav : MonoBehaviour
{
    public Transform[] waypoints;

    private int destinationIndex = 0;
    private NavMeshAgent agent;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Use NavMeshAgent to navigate cat
        agent = GetComponent<NavMeshAgent>();

        // Get the animator
        animator = GetComponent<Animator>();

        // Navigate
        Navigate();
    }

    // Update is called once per frame
    void Update()
    {
        // Navigate to the next point when close to the current one
        if (!agent.pathPending && agent.remainingDistance < 0.5f) {
            Navigate();
        }

        // Set the correct animation
        if (!agent.pathPending) {
            animator.SetBool("Walking", true);
        } else {
            animator.SetBool("Walking", false);
        }
    }

    void Navigate() {
        // If there are no waypoints, don't move
        if (waypoints.Length == 0) {
            return;
        }

        // Navigate to the selected destination
        agent.destination = waypoints[destinationIndex].position;

        // Pick the next destination randomly
        System.Random random = new System.Random();
        destinationIndex = random.Next(waypoints.Length);
    }
}
