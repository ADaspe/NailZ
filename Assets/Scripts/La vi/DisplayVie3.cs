﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayVie3 : MonoBehaviour
{
    public Coeur3Etat coeur;
    Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
       image.sprite = coeur.sr;
    }
}
