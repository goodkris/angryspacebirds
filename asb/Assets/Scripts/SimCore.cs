using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class SimCore : MonoBehaviour
{

    public GameObject planetPrefab;
    public bool flyByMode = false;
    GameObject planetToCreate;
    
    public List<GameObject> PlanetaryBodies; 
    public double simStepTime = 3600.0;
    public double gravity = -1.99356e-3; //-1.99356e-44; 


    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < PlanetaryBodies.Count; i++)
        //{
        //        PlanetaryBodies[i].GetComponent<PlanetaryBody>().setSimStep(simStepTime));
        //}
    }

    // Update is called once per frame
    void Update()
    {


        //double dt = simStepTime;  

        //float fx = 0.0F;
        //float fy = 0.0F;
        //float fz = 0.0F;        

        for(int i=0;i<PlanetaryBodies.Count;i++)
        {
            // update velocity vector on each planetary body.
            
            var pb = PlanetaryBodies[i].GetComponent<PlanetaryBody>();
            Debug.Log("Looking at Object: " + pb.ObjectName);
            double mass = pb.Mass;
            Vector3 posi = PlanetaryBodies[i].gameObject.transform.position;

            double dx = pb.posx;
            //float dy = pb.posy;
            double dz = pb.posz;

            double velocityx = pb.Velocityx;
            double velocityz = pb.Velocityz;
            double initvx = velocityx;
            double initvz = velocityz;

            for (int j=0; j<PlanetaryBodies.Count; j++)
            {
                if (i == j) continue;

                var pb2 = PlanetaryBodies[j].GetComponent<PlanetaryBody>();
                double mass2 = pb2.Mass;

                Vector3 posj = PlanetaryBodies[j].transform.gameObject.transform.position;
                double disx = pb2.pox - dxx;
                //var disy = pb2.posy - dy;
                double disz = pb2.posz -dz;

                Debug.Log("mass = " + mass + " mass2 = " + mass2 + " disx, z = " + disx +"   " + disz + " InitV " + velocityx + "   " + velocityz);

                double distSq = disx * disx + disz * disz; // + disy * disy + disz * disz;
                double invDist = 1.0 / Math.Sqrt(distSq);
                double accel = mass2 * invDist * invDist * gravity;

                // When you evaluate that you need to compute the components of the acceleration...
                //  The faster way really is to calculate the invDist, and take dist component * invDi * invDi * invDi


                Debug.Log("indDist " + invDist + " accel   " + accel);

                velocityx += (float)(disx * accel * invDist * simStepTime);
                //veli3.y += dt * disy * invDist3;
                velocityz += (float)(disz * accel * invDist * simStepTime);
                Debug.Log("New  Accelx " + velocityx + " Accely   " + velocityz);
            }

            // figure out the updated velocity vector after calculations...
            // calculations here!

            //var newVelocity = new Vector3(updatedX, updatedY, updatedZ);
            pb.Velocityx = velocityx;
            pb.Velocityz = velocityz;
            pb.posx += simStepTime * (initvx * 0.5 + velocityx);
            pb.posz += simStepTime * (initvz * 0.5 + velocityz);
        }

    }

    public void addPlanet()
    {

        var newPlanet = Instantiate(planetPrefab, gameObject.transform);
        planetToCreate = newPlanet;
        newPlanet.transform.position = new Vector3(0, 0, 0);

    }
}
