﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryBody : MonoBehaviour
{

    public Vector3 Velocity;
    public Vector3 InitialVelocity;
    public float rotationSpeed = 0.5f;
    public float Mass = 1;
    public float Size = 1;
    public float simStepTime = 3600.0F;
    public double posx = 0.0;
    public double posy = 0.0;
    public double posz = 0.0;


    // Start is called before the first frame update
    void Start()
    {
        posx = gameObject.transform.position.x;
        posy = gameObject.transform.position.y;
        posz = gameObject.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        // update object's position based on velocity


        Debug.Log("position = " + gameObject.transform.position + " New Vel = " + Velocity);
        gameObject.transform.position += Velocity;

        gameObject.transform.Rotate(new Vector3(0, rotationSpeed, 0));
    }
}
