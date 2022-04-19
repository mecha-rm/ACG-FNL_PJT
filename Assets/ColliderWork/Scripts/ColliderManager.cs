using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{

    public VolumetricTrigger[] Volumetric_Trigger_List;
    public VolumetricCollider[] Volumetric_Collider_List;

    public List<Collider_Bool> Trigger_List = new List<Collider_Bool>();
    public List<Collider_Bool> Collider_List = new List<Collider_Bool>();




    private void Start()
    {
        Volumetric_Trigger_List = this.GetComponentsInChildren<VolumetricTrigger>();
        Volumetric_Collider_List = this.GetComponentsInChildren<VolumetricCollider>();

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

        foreach (Collider_Bool cb in Trigger_List)
        {
            //print(cb.Name);
        }

        foreach (Collider_Bool cb in Collider_List)
        {
            print(cb.Name);
        }
    }

    //void Update()
    //{
    //    
    //}


    //** TRIGGER EVENTS ** \\

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