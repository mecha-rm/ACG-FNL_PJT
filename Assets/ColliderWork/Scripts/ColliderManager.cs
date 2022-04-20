using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{

    // This Handles the children of the Manager 

    public VolumetricTrigger[] Volumetric_Trigger_List;
    public VolumetricCollider[] Volumetric_Collider_List;

    //These hold the Boolean pair for each collider (if its colliding or not).

    public List<Collider_Bool> Trigger_List = new List<Collider_Bool>();
    public List<Collider_Bool> Collider_List = new List<Collider_Bool>();




    private void Start()
    {
        //Get Children..

        Volumetric_Trigger_List = this.GetComponentsInChildren<VolumetricTrigger>();
        Volumetric_Collider_List = this.GetComponentsInChildren<VolumetricCollider>();

        //Add them to their proper lists..

        foreach (VolumetricTrigger vt in Volumetric_Trigger_List)
        {
            Trigger_List.Add(new Collider_Bool(vt.gameObject.name));
           // Debug.Log("Added Trigger Boolean");
        }

        foreach (VolumetricCollider vc in Volumetric_Collider_List)
        {
            Collider_List.Add(new Collider_Bool(vc.gameObject.name));
            Debug.Log("Added Collider Boolean");
        }

        //foreach (Collider_Bool cb in Trigger_List)
        //{
        //    //print(cb.Name);
        //}
        //
        //foreach (Collider_Bool cb in Collider_List)
        //{
        //    print(cb.Name);
        //}
    }

    //void Update()
    //{
    //    
    //}


    //** TRIGGER EVENTS ** \\
    
    //The for each loop finds which trigger or collider was tripped, then sets their boolean pair to true.

    public void CollisionDetected_TriggerEnter(Collider other, string col_name)
    {
        //Debug.Log("Collider Detected!");

        //Collider_Bool temp = null;

        foreach (Collider_Bool cb in Trigger_List)
        {
            if(cb.Name == col_name)
            {
                cb.SetColliding(true);

                
                //temp = cb;
                break;
            }
        }

        //if(temp != null)
        //{
        //    print(temp.Name);
        //    print(temp.isColliding);
        //}

        
    }

    public void CollisionDetected_TriggerStay(Collider other,string col_name)
    {

        //foreach (Collider_Bool cb in Trigger_List)
        //{
        //    if (cb.Name == col_name)
        //    {
        //        cb.SetColliding(true);
        //
        //
        //        //temp = cb;
        //        break;
        //    }
        //}

    }

    public void CollisionDetected_TriggerExit(Collider other, string col_name)
    {
        foreach (Collider_Bool cb in Trigger_List)
        {
            if (cb.Name == col_name)
            {
                cb.SetColliding(false);

                //temp = cb;
                break;
            }
        }
    }

    //** TRIGGER EVENTS ** \\




    //** COLLISION EVENTS ** \\

    public void CollisionDetected_CollisionEnter(Collision other, string col_name)
    {
        Debug.Log("Collision Detected!");

        foreach (Collider_Bool cb in Collider_List)
        {
            if (cb.Name == col_name)
            {
                cb.SetColliding(true);

                break;
            }
        }

        

    }

    public void CollisionDetected_CollisionStay(Collision other, string col_name)
    {
        //Debug.Log("Collision Detected!");

        //foreach (Collider_Bool cb in Collider_List)
        //{
        //    if (cb.Name == col_name)
        //    {
        //        cb.SetColliding(true);
        //
        //        break;
        //    }
        //}



    }

    public void CollisionDetected_CollisionExit(Collision other, string col_name)
    {
        //Debug.Log("Collision Detected!");

        foreach (Collider_Bool cb in Collider_List)
        {
            if (cb.Name == col_name)
            {
                cb.SetColliding(false);

                break;
            }
        }

    }



    //** COLLISION EVENTS ** \\



    // Whenever a Volumetric Collider is disabled, it sets the corresponding boolean pair to false.
    public void CleanDeactivate(string col_name)
    {
        foreach (Collider_Bool cb in Trigger_List)
        {
            if (cb.Name == col_name)
            {
                cb.SetColliding(false);


                //temp = cb;
                break;
            }
        }

        foreach (Collider_Bool cb in Collider_List)
        {
            if (cb.Name == col_name)
            {
                cb.SetColliding(false);


                //temp = cb;
                break;
            }
        }
    }

    //This is a check for a specific collider to see if it has been triggered.
    public bool Check_For_Collision(string col_name)
    {
        foreach (Collider_Bool cb in Trigger_List)
        {
            if (cb.Name == col_name)
            {

                return cb.isColliding;

                //temp = cb;
                
            }
        }

        foreach (Collider_Bool cb in Collider_List)
        {
            if (cb.Name == col_name)
            {

                return cb.isColliding;

                //temp = cb;

            }
        }

        return false;
    }


    //This checks all colliders and returns true if any of them are tripped.
    public bool Check_For_Collision_Any()
    {
        foreach (Collider_Bool cb in Trigger_List)
        {
            if (cb.isColliding)
            {

                return cb.isColliding;

                //temp = cb;

            }
        }

        foreach (Collider_Bool cb in Collider_List)
        {
            if (cb.isColliding)
            {

                return cb.isColliding;

                //temp = cb;

            }
        }

        return false;
    }

}


public class Collider_Bool
{

    public string Name;
    public bool isColliding;

    public Collider_Bool(string name)
    {
        Name = name;
        isColliding = false;
    }

    public void SetColliding(bool b)
    {
        isColliding = b;
    }

}