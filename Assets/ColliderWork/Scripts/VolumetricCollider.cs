using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumetricCollider : MonoBehaviour
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
    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collider hit");

        Manager.CollisionDetected_CollisionEnter(other, this.gameObject.name);
    }

    public void OnCollisionStay(Collision other)
    {
        Manager.CollisionDetected_CollisionStay(other, this.gameObject.name);
    }

    public void OnCollisionExit(Collision other)
    {
        Manager.CollisionDetected_CollisionExit(other, this.gameObject.name);
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