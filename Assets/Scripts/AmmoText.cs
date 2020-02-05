using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour
{
    private int ammo;
    Text ammoText;

    // Start is called before the first frame update
    void Start()
    {
        ammoText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ammo = Shooting.actualNailAmmo;
        ammoText.text = "ammunition : " + ammo;
    }
}
