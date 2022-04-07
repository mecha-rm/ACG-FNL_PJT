using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{

    public Actor Track_Target; //The Actor or Volumetric Video we are attached to.

    public bool Parented = true; //Is this a separated Manager?

    public Vector3 OffSet; //To help reach the appropriate origin.

    void Update()
    {
        if (!Parented){
            transform.position = Track_Target.transform.position + OffSet;
        }
    }

    public void CollisionDetected_TriggerEnter(Collider other)
    {
        Debug.Log("Passing hit");

        Track_Target.RecieveEnterTriggerCollision(0);

    }
    
}
