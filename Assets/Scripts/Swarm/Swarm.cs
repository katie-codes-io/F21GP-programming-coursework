using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Swarm : MonoBehaviour
{
    // Define a swarm agent object and swarm behaviour
    public GameObject agent;
    public SwarmBehaviour behaviour;

    // Initialise an agent list
    List<GameObject> agents = new List<GameObject>();

    // Customisable swarm features
    public int   count           = 20;      // number of agents in swarm
    public float density         = 0.5f;    // agent swarm density
    public float speed           = 5.0f;    // agent speed
    public float agentRadius     = 1.0f;    // agent collision radius
    public float avoidanceRadius = 0.5f;    // agent avoidance radius
    public float obstacleRadius  = 1.0f;    // agent obstacle avoidance radius

    // Start is called before the first frame update
    void Start()
    {
        // Start populating the swarm
        for (int i = 0; i < count; i++) {

            // Set the starting agent position in the swarm randomly in a sphere with radius = count * density
            Vector3 pos = Random.insideUnitSphere * count * density;

            // Update the x and z coordinates to be relative to the spawn position
            pos.x += transform.position.x;
            pos.z += transform.position.z;

            // We only want to spawn on the ground so set y appropriately
            pos.y = 0.05f;

            // Instantiate an agent object
            GameObject newAgent = Instantiate(
                agent,                // set the agent object
                pos,                  // set the position
                transform.rotation,   // set the rotation from the parent
                transform             // set the swarm parent
            );

            // Add new agent to agents list
            agents.Add(newAgent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Iterate through the agents in the swarm
        foreach (GameObject agent in agents) {

            // Get neighbours and obstacles
            List<Transform> neighbours = GetAdjacent(agent, new string[] {"Bug"});
            List<Transform> obstacles  = GetAdjacent(agent, new string[] {"Player", "Cat", "Wall"});

            // Calculate movement according to neighbours and obstacles
            Vector3 move = behaviour.CalculateMove(agent, this, neighbours, obstacles);

            // Scale by speed
            move *= speed;
            
            // Apply speed and transform agent
            agent.transform.forward   = move;
            agent.transform.position += move * Time.deltaTime;
        }
    }

    // Method to get adjacent objects by tag
    List<Transform> GetAdjacent(GameObject agent, string[] tags) {

        // Get the list of neighbours ready
        List<Transform> neighbours = new List<Transform>();

        // Get all overlapping colliders
        Collider[] colliders = Physics.OverlapSphere(agent.transform.position, agentRadius);

        // Iterate through the colliders
        foreach (Collider collider in colliders) {

            // First make sure to not include self
            if (collider != agent.GetComponent<Collider>()) {

                // Check if collider has correct tag
                if (tags.Contains(collider.tag)) {
                    // add to the neighbours
                    neighbours.Add(collider.transform);
                }
            }
        }

        return neighbours;
    }
}
