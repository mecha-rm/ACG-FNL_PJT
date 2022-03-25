    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumetricCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public ColliderManager Manager;

    void Start()
    {
        if (!Manager) //Check if not set
        {
            Manager = this.transform.parent.gameObject.GetComponent<ColliderManager>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collider hit");

        Manager.CollisionDetected_TriggerEnter(other);
    }
}
