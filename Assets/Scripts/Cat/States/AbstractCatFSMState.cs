using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Declare enum to keep track of the state execution state
public enum ExecutionState {
    NONE,
    ACTIVE,
    COMPLETED
}

// Declare enum to keep track of the state
public enum StateType {
    IDLE,
    PATROL
}

public abstract class AbstractCatFSMState : ScriptableObject
{
    //=========================================================//
    // Declare the protected variables that the state classes will need
    protected NavMeshAgent agent;
    protected Animator animator;
    protected CatNPC npc;
    protected CatFSM fsm;

    // Declare inline properties
    public ExecutionState ExecutionState { get; protected set; }
    public StateType StateType { get; protected set; }

    // Declare boolean which keeps track of whether the state has been entered
    public bool EnteredState { get; protected set; }

    //=========================================================//
    // Define abstract/virtual methods to be implemented by
    // inheriting classes

    public abstract void UpdateState();

    public virtual void InitState()
    {
        ExecutionState = ExecutionState.NONE;
    }

    public virtual void EnterState()
    {
        // Check if we have valid NavMeshAgent, Animator, CatNPC and CatFSM components
        if (agent != null & animator != null & npc != null & fsm != null) {
            ExecutionState = ExecutionState.ACTIVE;
            EnteredState = true;
        }
    }

    public virtual void ExitState()
    {
        ExecutionState = ExecutionState.COMPLETED;
        EnteredState = false;
    }

    //=========================================================//
    // Define setters

    public virtual void SetNavMeshAgent(NavMeshAgent agent)
    {
        if (agent != null) {
            this.agent = agent;
        }
    }

    public virtual void SetAnimator(Animator animator)
    {
        if (animator != null) {
            this.animator = animator;
        }
    }

    public virtual void SetNPC(CatNPC npc)
    {
        if (npc != null) {
            this.npc = npc;
        }
    }

    public virtual void SetFSM(CatFSM fsm)
    {
        if (fsm != null) {
            this.fsm = fsm;
        }
    }
}


