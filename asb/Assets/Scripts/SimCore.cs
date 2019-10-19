using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimCore : MonoBehaviour
{

    public List<GameObject> PlanetaryBodies; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<PlanetaryBodies.Count;i++)
        {
            // update velocity vector on each planetary body.

            var pb = PlanetaryBodies[i].GetComponent<PlanetaryBody>();
            float updatedX = 0;
            float updatedY = 0;
            float updatedZ = 0;

            // figure out the updated velocity vector after calculations...
            // calculations here!

            var newVelocity = new Vector3(updatedX, updatedY, updatedZ);
            pb.Velocity = newVelocity;
        }
    }
}
