
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


        float dt = 0.1F;  




        //float fx = 0.0F;
        //float fy = 0.0F;
        //float fz = 0.0F;        

        for(int i=0;i<PlanetaryBodies.Count;i++)
        {
            // update velocity vector on each planetary body.

            var pb = PlanetaryBodies[i].GetComponent<PlanetaryBody>();
            Vector3 posi = PlanetaryBodies[i].gameObject.transform.position;

            float dx = posi.x;
            //float dy = posi.y;
            float dz = posi.z;

            Vector3 veli3 = pb.Velocity;

            for (int j=0; j<PlanetaryBodies.Count; j++)
            {
                if (i == j) continue;

                Vector3 posj = PlanetaryBodies[j].transform.gameObject.transform.position;
                var disx = dx - posj.x;
                //var disy = dy - posj.y;
                var disz = dz - posj.z;

                float distSq = disx * disx + disz * disz; // + disy * disy;
                float invDist = 1.0F / Mathf.Sqrt(distSq);
                float invDist3 = invDist * invDist * invDist;

                veli3.x += dt * disx * invDist3;
                //veli3.y += dt * disy * invDist3;
                veli3.z += dt * disz * invDist3;
            }

            // figure out the updated velocity vector after calculations...
            // calculations here!

            //var newVelocity = new Vector3(updatedX, updatedY, updatedZ);
            pb.Velocity = veli3;
        }
    }
}
