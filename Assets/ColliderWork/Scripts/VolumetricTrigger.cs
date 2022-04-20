    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumetricTrigger : MonoBehaviour
{
    
    public ColliderManager Manager;  
    private Collider my_collider; //The default collider

    void Start()
    {
        if (!Manager) //Check if not set
        {
            Manager = this.transform.parent.gameObject.GetComponent<ColliderManager>();
        }

        my_collider = GetComponent<Collider>();
    }


    // Trigger Events..
    // The name of the collider that fired is passed to the manager

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collider hit");

        Manager.CollisionDetected_TriggerEnter(other, this.gameObject.name);
    }

    public void OnTriggerStay(Collider other)
    {
        Manager.CollisionDetected_TriggerStay(other, this.gameObject.name);
    }

    public void OnTriggerExit(Collider other)
    {
        Manager.CollisionDetected_TriggerExit(other, this.gameObject.name);
    }


    //Activates the collider to receive collisions.

    public void Activate()
    {
        my_collider.enabled = true;
    }


    //Disables the collider from receiving collisions.
    public void Deactivate()
    {
        my_collider.enabled = false;

        Manager.CleanDeactivate(this.gameObject.name);
    }
}
