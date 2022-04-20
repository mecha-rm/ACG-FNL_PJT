using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    Renderer cubeRenderer;

    public ColliderManager Manager;

    public Material bl;
    public Material rd;

    private bool Blue = true;

    // Start is called before the first frame update
    void Start()
    {
        cubeRenderer = GetComponent<Renderer>(); //Get the renderer
        cubeRenderer.material.SetColor("_Color", Color.blue);

        Debug.Log(Manager);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecieveEnterTriggerCollision(int i)
    {
        Debug.Log("Hit Recieved.");

        if (i == 0)
        {
            Debug.Log("Changing Color.");

            if (Blue)
            {
                cubeRenderer.material = rd;
                Blue = false;
                Debug.Log("Red.");
            }
            else 
            {
                cubeRenderer.material = bl;
                Blue = true;
                Debug.Log("Blue.");
            }
               

        }
    }
}
