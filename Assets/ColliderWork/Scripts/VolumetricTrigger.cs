    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumetricTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public ColliderManager Manager;
    private Collider my_collider;

    void Start()
    {
        if (!Manager) //Check if not set
        {
            Manager = this.transform.parent.gameObject.GetComponent<ColliderManager>();
        }

        my_collider = GetComponent<Collider>();
    }


    //First Entry
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
        
    }

    public void Activate()
    {
        my_collider.enabled = true;
    }

    public void Deactivate()
    {
        my_collider.enabled = false;

        Manager.CleanDeactivate(this.gameObject.name);
    }
}
