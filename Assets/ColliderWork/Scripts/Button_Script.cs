using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Script : MonoBehaviour
{

    public Material rd;
    public Material gr;

    Renderer cubeRenderer;

    public GameObject Block;
    public ColliderManager Manager;


    private bool green = true;


    // Start is called before the first frame update
    void Start()
    {
        cubeRenderer = GetComponent<Renderer>(); //Get the renderer
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPressed()
    {

        if (Manager.Check_For_Collision("R_Hand_Trigger"))
        {

            Block.GetComponent<Rigidbody>().isKinematic = false;

            print("Falling");
        
        }


    }

}
