﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(CatFSM))]
public class CatNPC : MonoBehaviour
{

    //=========================================================//
    // Declare public variables
    public Transform[] waypoints;
    public GameObject[] players;
    public float playerDistance;
    public float playerAngle;

    // Declare private variables
    private NavMeshAgent agent;
    private CatFSM catFSM;
    private GameObject player;

    // Declare inline properties
    public GameObject Player { get; set; }

    //=========================================================//
    // Declare lifecycle methods
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        catFSM = GetComponent<CatFSM>();
    }

    void Update()
    {
        // Check for players within threshold
        if (players != null & players.Length > 0) {
            foreach (GameObject followPlayer in players) {
                // Get the distance and angle
                float distance = Vector3.Distance(followPlayer.transform.position, transform.position);
                float angle = Vector3.Angle(transform.position, followPlayer.transform.position);
                
                // Compare the distance and angle to thresholds
                if (distance <= playerDistance & angle < playerAngle) {
                    Player = followPlayer;
                }
            }

        }
    }

}