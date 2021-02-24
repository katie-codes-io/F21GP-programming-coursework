using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "State/Follow")]
public class CatFollowState : AbstractCatFSMState
{
    //=========================================================//
    // Declare public variables
    public float duration = 5f;
    public float followSpeed = 5f;
    public float angularSpeed = 360f;
    public float acceleration = 5f;

    // Declare private variables
    private GameObject player;
    private float followDuration;

    //=========================================================//
    // Declare private methods

    private void Follow() {
        
        // Follow the player
        agent.SetDestination(player.transform.position);

        // Set the walk animation
        animator.SetBool("Walking", true);
    }

    //=========================================================//
    // Implement abstract/virtual methods

    public override void OnEnable()
    {
        base.OnEnable();

        // Set the state type to follow
        StateType = StateType.FOLLOW;
    }

    public override void EnterState()
    {
        base.EnterState();

        // Check if we entered the state first
        if (EnteredState)
        {
            // Reset the follow duration
            followDuration = 0f;

            // Get the player
            player = npc.Player;

            // Check if we have a player
            if (player != null)
            {
                // Set the meowing animation
                audio.Play();

                // Set the NavMeshAgent values
                agent.speed = followSpeed;
                agent.acceleration = acceleration;
                agent.angularSpeed = angularSpeed;

                // Follow!
                Follow();

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
            // Increment the follow duration
            followDuration += Time.deltaTime;

            // Check if follow duration has maxed out, if so, idle
            if (followDuration >= duration)
            {
                ExitState();
                fsm.EnterState(StateType.IDLE);

                // Reset the NavMeshAgent values
                agent.speed = 1.0f;
                agent.acceleration = 1.0f;
                agent.angularSpeed = 180f;

            } else {
                // Keep updating the position to follow player
                Follow();
            }
        }
    }

    public override void ExitState()
    {
        base.ExitState();

        // Reset the followed player
        player = null;
        npc.Player = null;
    }

}
