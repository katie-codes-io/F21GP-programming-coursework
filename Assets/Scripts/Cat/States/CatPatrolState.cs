using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "State/Patrol")]
public class CatPatrolState : AbstractCatFSMState
{
    //=========================================================//    
    // Declare public variables
    public float duration = 5f;

    // Declare private variables
    private Transform[] waypoints;
    private int destinationIndex;
    private float patrolDuration;

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

    public override void OnEnable()
    {
        base.OnEnable();

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
            // Reset the patrol duration
            patrolDuration = 0f;

            // Get the waypoints from the NPC component
            waypoints = npc.waypoints;

            // Check if we have waypoints
            if (waypoints != null & waypoints.Length > 0)
            {
                // Navigate!
                Navigate();

            } else {
                // Exit state properly
                ExitState();
            }
        }

    }

    public override void UpdateState()
    {
        // Check if we entered the state first
        if (EnteredState)
        {
            // Increment the patrol duration
            patrolDuration += Time.deltaTime;

            // Check if we've encountered a player that should be followed
            if (npc.Player != null)
            {
                ExitState();
                fsm.EnterState(StateType.FOLLOW);
            }
            // Check if patrol duration has maxed out, if so, follow/idle
            else if (patrolDuration >= duration)
            {
                ExitState();
                fsm.EnterState(StateType.IDLE);
            }
            // Check if we need to set another waypoint
            else if (!agent.pathPending & agent.remainingDistance < 0.5f)
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
