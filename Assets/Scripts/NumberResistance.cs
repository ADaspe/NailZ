using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberResistance : MonoBehaviour
{
    private Door number;
    private GameObject porte;
    Text resistance;

    void Start()
    {
        number = GetComponentInParent<Door>();
        resistance = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
            resistance.text = "" + number.nailCounter;
    }
}