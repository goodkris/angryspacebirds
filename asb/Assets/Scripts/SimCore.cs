using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class SimCore : MonoBehaviour
{

    public GameObject planetPrefab;
    public Camera camera;
    public bool flyByMode = false;
    GameObject planetToCreate;
    
    public List<GameObject> PlanetaryBodies; 
    public double simStepTime = 60.0;
    public double gravity = -1.99356e-44; 


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
            double mass = pb.Mass;
            Vector3 posi = PlanetaryBodies[i].gameObject.transform.position;

            double dx = posi.x;
            //float dy = posi.y;
            double dz = posi.z;

            Vector3 veli3 = pb.Velocity;

            for (int j=0; j<PlanetaryBodies.Count; j++)
            {
                if (i == j) continue;

                var pb2 = PlanetaryBodies[j].GetComponent<PlanetaryBody>();
                double mass2 = pb2.Mass;

                Vector3 posj = PlanetaryBodies[j].transform.gameObject.transform.position;
                double disx = dx - posj.x;
                //var disy = dy - posj.y;
                double disz = dz - posj.z;

                Debug.Log("mass = " + mass + " mass2 = " + mass2 + " disx, z = " + disx.ToString("F8") +"   " + disz.ToString("F8") + " Vel " + veli3.x.ToString("F8") + "   " + veli3.z.ToString("F8"));

                double distSq = disx * disx + disz * disz; // + disy * disy;
                double invDist = 1.0 / Math.Sqrt(distSq);
                //float invDist3 = gravity * mass * Mathf.Abs(invDist * invDist * invDist);
                double accel = mass2 * Math.Abs(invDist * invDist * invDist) * gravity;
                Debug.Log("indDist " + invDist.ToString("F8") + " accel   " + accel.ToString("F45"));

                veli3.x += (float)(disx * accel);
                //veli3.y += dt * disy * invDist3;
                veli3.z += (float)(disz * accel);
                Debug.Log("New  Vel " + veli3.x.ToString("F") + "   " + veli3.z.ToString("F"));
            }

            // figure out the updated velocity vector after calculations...
            // calculations here!

            //var newVelocity = new Vector3(updatedX, updatedY, updatedZ);
            pb.Velocity = veli3;
        }
        

        if (Input.GetKeyDown(KeyCode.F))
        {
            camera.GetComponent<CameraControl>().enabled = flyByMode;
            flyByMode = !flyByMode;

        }
      

    }

    public void addPlanet()
    {

        var newPlanet = Instantiate(planetPrefab, gameObject.transform);
        planetToCreate = newPlanet;
        newPlanet.transform.position = new Vector3(0, 0, 0);

    }
}
