using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// generates a collider.

public class MeshColliderGenerator : MonoBehaviour
{
    // the attached object this mesh collider will be given to.
    public GameObject linkedObject;

    // the mesh renderer for this collider generator.
    public MeshRenderer mr;

    // the box collider that will be attached.
    public BoxCollider boxCollider;

    // if 'true' a new collider gets made regardless.
    // if 'false', an existing collider is used if available.
    public bool makeNewCollider = true;

    // Start is called before the first frame update
    void Start()
    {
        // saves the game object.
        if (linkedObject == null)
            linkedObject = gameObject;

        // grabs the mesh renderer from the attached object.
        if (mr == null)
            mr = linkedObject.GetComponent<MeshRenderer>();

        // generates the collider.
        if(mr != null)
            GenerateCollider();
    }

    // generates the collider.
    public void GenerateCollider()
    {
        // attaches the collider.
        boxCollider = null;

        // grabs the box collider if it shouldn't reuse one.
        if (makeNewCollider || (!makeNewCollider && !linkedObject.TryGetComponent<BoxCollider>(out boxCollider)))
        {
            // adds a box collider.
            boxCollider = linkedObject.AddComponent<BoxCollider>();
        }

        // changes collider size.
        boxCollider.size = mr.bounds.size;
        boxCollider.center = mr.bounds.center;

    }

    // Update is called once per frame
    void Update()
    {
        // // the box collider size was not properly set yet.
        // if (boxCollider.size == Vector3.zero)
        //     GenerateCollider();
    }
}
