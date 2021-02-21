using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Swarm/SwarmBehaviour")]
public class SwarmBehaviour : ScriptableObject
{
    // Define editable weights for the different behaviour components
    public float alignmentWeight           = 1.0f;
    public float avoidanceWeight           = 1.0f;
    public float cohesionWeight            = 1.0f;
    public float obstacleAvoidanceWeight   = 1.0f;
    public float sunflowerAttractionWeight = 1.0f;

    // Initialise private instance variables
    private GameObject agent;
    private Swarm swarm;
    private List<Transform> neighbours = new List<Transform>();
    private List<Transform> obstacles = new List<Transform>();
    private List<Transform> sunflowers = new List<Transform>();

    // Calculate move
    public Vector3 CalculateMove(GameObject agent, Swarm swarm, List<Transform> neighbours, List<Transform> obstacles, List<Transform> sunflowers) {

        // Assign to instance variables
        this.agent      = agent;
        this.swarm      = swarm;
        this.neighbours = neighbours;
        this.obstacles  = obstacles;
        this.sunflowers = sunflowers;

        // Initialise move
        Vector3 move = Vector3.zero;

        // First check to see if we have any neighbours, obstacles or sunflowers to deal with
        if (neighbours.Count > 0 || obstacles.Count > 0 || sunflowers.Count > 0) {

            // Perform alignment and append weighted vector to movement
            move += CalculateAlignment();

            // Perform avoidance and append weighted vector to movement
            move += CalculateAvoidance();

            // Perform cohesion and append weighted vector to movement
            move += CalculateCohesion();
        }

        // Normalize to ensure the vector magnitude remains equal to 1 and return the move
        move.Normalize();
        return move;
    }

    private Vector3 CalculateAlignment() {

        Vector3 move = Vector3.zero;

        // Iterate through the neighbours getting the forward direction
        foreach (Transform transform in neighbours) {

            if (transform != null) {
                // Weigh the movement by alignment weight
                move += alignmentWeight * (transform.transform.forward);
            }
        }

        // Scale by number of neighbours
        move /= neighbours.Count;

        return move;
    }

    private Vector3 CalculateAvoidance() {

        Vector3 move       = Vector3.zero;
        int avoidCount     = 0;

        // Iterate through the neighbours getting the difference in position to self
        foreach (Transform transform in neighbours) {
            
            if (transform != null) {
                // Check if the neighbours are within the avoidance radius
                if (Vector3.SqrMagnitude(transform.position - agent.transform.position) < swarm.avoidanceRadius)
                {
                    // Weigh the movement by avoidance weight
                    move += avoidanceWeight * (agent.transform.position - transform.position);
                    avoidCount++;
                }
            }
        }

        // Iterate through the obstacles getting the difference in position to self
        foreach (Transform transform in obstacles) {

            if (transform != null) {
                // Weigh the movement by obstacle avoidance weight
                move += obstacleAvoidanceWeight * (agent.transform.position - transform.position);

            }
        }

        // Iterate through the sunflowers getting the position
        foreach (Transform transform in sunflowers) {

            if (transform != null) {
                // Weigh the movement by sunflower attraction weight
                move += sunflowerAttractionWeight * (transform.position - agent.transform.position);
            }
        }

        // Scale by number of neighbours, obstacles and sunflowers
        if ((avoidCount + obstacles.Count + sunflowers.Count) > 0)
            move /= (avoidCount + obstacles.Count + sunflowers.Count);

        return move;

    }

    private Vector3 CalculateCohesion() {
        
        Vector3 move = Vector3.zero;

        // Iterate through the neighbours getting the position
        foreach (Transform transform in neighbours) {

            if (transform != null) {
                // Weigh the movement by cohesion weight
                move += cohesionWeight * transform.position;
            }
        }

        // Scale by number of neighbours
        move /= neighbours.Count;

        // Remove self position otherwise the movement does not work very well
        move -= agent.transform.position;

        return move;
    }

}
