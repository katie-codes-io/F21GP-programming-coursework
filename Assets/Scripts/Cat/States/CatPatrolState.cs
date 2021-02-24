using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "State/Patrol")]
public class CatPatrolState : AbstractCatFSMState
{
    //=========================================================//
    // Declare private variables
    private Transform[] waypoints;
    private int destinationIndex;

    //=========================================================//
    // Declare private methods

    private void Navigate() {

        // Navigate to a random destination
        destinationIndex = Random.Range(0, waypoints.Length);
        agent.SetDestination(waypoints[destinationIndex].position);

        // Set the walk animation
        animator.SetBool("Walking", true);
    }

    //=========================================================//
    // Implement abstract/virtual methods

    public override void InitState()
    {
        base.InitState();

        // Set the state type to patrol
        StateType = StateType.PATROL;

        // Set the first destination index
        destinationIndex = 0;
    }

    public override void EnterState()
    {
        base.EnterState();

        // Check if we entered the state first
        if (EnteredState)
        {
            // Get the waypoints from the NPC component
            waypoints = npc.waypoints;

            // Check if we have waypoints
            if (waypoints != null & waypoints.Length > 0)
            {
                // Navigate!
                Navigate();

            } else {
                // Exit state properly
                base.ExitState();
            }
        }

    }

    public override void UpdateState()
    {
        // Check if we entered the state first
        if (EnteredState)
        {
            // Check if we need to set another waypoint
            if (!agent.pathPending & agent.remainingDistance < 0.5f)
            {
                // Navigate!
                Navigate();
            }
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }

}
