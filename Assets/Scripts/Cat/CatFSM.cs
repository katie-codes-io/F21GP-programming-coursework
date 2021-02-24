using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatFSM : MonoBehaviour
{
    //=========================================================//
    // Declare public variables
    public AbstractCatFSMState initialState;
    public List<AbstractCatFSMState> validStates;
    
    //=========================================================//
    // Declare private variables
    private AbstractCatFSMState currentState;
    private Dictionary<StateType, AbstractCatFSMState> fsmStates;

    //=========================================================//
    // Declare lifecycle methods

    void Awake()
    {
        // Initially, set the current state to null
        currentState = null;

        // Populate the Finite State Machine state dictionary for lookup
        fsmStates = new Dictionary<StateType, AbstractCatFSMState>();
        foreach (AbstractCatFSMState state in validStates)
        {
            // Set the state components
            state.SetNavMeshAgent(GetComponent<NavMeshAgent>());
            state.SetAnimator(GetComponent<Animator>());
            state.SetNPC(GetComponent<CatNPC>());
            state.SetFSM(this);

            // Add the state to the dictionary
            fsmStates.Add(state.StateType, state);
        }
    }

    void Start()
    {
        if (initialState != null) {
            currentState = initialState;
            initialState.EnterState();
        }
    }

    void Update()
    {
        if (currentState != null) {
            currentState.UpdateState();
        }
    }

    //=========================================================//
    // Declare public methods
    public void EnterState(StateType stateType)
    {
        // First, check the state type is in the dictionary
        if (fsmStates.ContainsKey(stateType))
        {
            // Get the state from the dictionary
            AbstractCatFSMState state = fsmStates[stateType];

            // Exit the current state
            if (currentState != null)
            {
                currentState.ExitState();
            }

            // Set the current state to this state and enter state
            currentState = state;
            currentState.EnterState();

        }
    }

}
