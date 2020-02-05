using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayVie : MonoBehaviour
{
    public Coeur1Etat coeur;
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
