using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulle : MonoBehaviour
{
    private bool plankOnDoor;
    public Door porte;
    
    void Start()
    {
        this.gameObject.GetComponent<Renderer>().enabled = false;
        porte = GetComponentInParent<Door>();

    }
    void Update()
    {
        plankOnDoor = porte.plankOrNot;

        if (plankOnDoor == true)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
