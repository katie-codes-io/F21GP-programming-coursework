using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public float step;
    public float speed;
    private GameObject[] sunflowers = new GameObject[9];
    private GameObject sunflower;

    // Start is called before the first frame update
    void Start()
    {
        // float mass;
        // float position;
        // float velocity;
        // float max_force;
        // float max_speed;
        // float orientation;

        speed = 1.0f;
        sunflowers = GameObject.FindGameObjectsWithTag("Sunflower");

        System.Random random = new System.Random();
        int index = random.Next(sunflowers.Length);
        sunflower = sunflowers[index];

    }

    // Update is called once per frame
    void Update()
    {
        // move boid to sunflower
        if (sunflower != null) {
            step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, sunflower.transform.position, step);
        }

    }
}
