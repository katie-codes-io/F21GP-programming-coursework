using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(CatFSM))]
public class CatNPC : MonoBehaviour
{

    //=========================================================//
    // Declare public variables
    public Transform[] waypoints;

    //=========================================================//
    // Declare private variables
    private NavMeshAgent agent;
    private CatFSM catFSM;

    //=========================================================//
    // Declare lifecycle methods
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        catFSM = GetComponent<CatFSM>();
    }
}
