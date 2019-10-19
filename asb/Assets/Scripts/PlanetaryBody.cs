using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryBody : MonoBehaviour
{

    public Vector3 Velocity;
    public Vector3 InitialVelocity;
    public float rotationSpeed = 0.5f;
    public float Mass = 1;
    public float Size = 1;
    public int StepSize = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // update object's position based on velocity
        gameObject.transform.position += Velocity;

        gameObject.transform.Rotate(new Vector3(0, rotationSpeed, 0));
    }
}
