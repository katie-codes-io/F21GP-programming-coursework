using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State/Idle")]
public class CatIdleState : AbstractCatFSMState
{
    //=========================================================//
    // Declare public variables
    public float duration = 5f;

    // Declare private variables
    private float idleDuration;

    //=========================================================//
    // Implement abstract/virtual methods

    public override void OnEnable()
    {
        base.OnEnable();

        // Set the state type to idle
        StateType = StateType.IDLE;
    }

    public override void EnterState()
    {
        base.EnterState();

        // Check if we entered the state first
        if (EnteredState)
        {

            // Reset the idle duration
            idleDuration = 0f;

            // Make sure the animator transitions to idle animation
            animator.SetBool("Walking", false);
        }

    }

    public override void UpdateState()
    {
        // Check if we entered the state first
        if (EnteredState) {

            // Increment the idle duration
            idleDuration += Time.deltaTime;

            // Check if idle duration has maxed out, if so, patrol
            if (idleDuration >= duration)
            {
                if (npc.Player != null) {
                    ExitState();
                    fsm.EnterState(StateType.FOLLOW);
                }
                else
                {
                    ExitState();
                    fsm.EnterState(StateType.PATROL);
                }
            }
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }

}
