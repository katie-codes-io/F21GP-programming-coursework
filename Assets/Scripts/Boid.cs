﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public float step;
    public float speed;
    public GameObject[] sunflowers = new GameObject[9];
    public GameObject sunflower;

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
        Debug.Log(index);
        sunflower = sunflowers[index];

    }

    // Update is called once per frame
    void Update()
    {
        // move boid to sunflower
        // sunflower.transform.position;

        step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, sunflower.transform.position, step);

    }
}