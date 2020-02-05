using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coeur3Etat : MonoBehaviour
{
    public bool CoeurOn;
    [HideInInspector] public Sprite sr;
    public Sprite CoeurRougeSprite;
    public Sprite CoeurNoirSprite;
    private int Vie;
    VieJoueur vieJoueur;

    private void Start()
    {
        CoeurOn = true;
        vieJoueur = GetComponent<VieJoueur>();
    }
    void Update()
    {
        Vie = vieJoueur.SanteJoueur;
        if (Vie <= 2)
        {
            Debug.Log("Sante joueur 0");
            CoeurOn = false;
        }
        else
        {
            CoeurOn = true;
        }
        CoeurEtat();

    }

    void CoeurEtat()
    {
        if (CoeurOn == false)
        {
            sr = CoeurNoirSprite;
        }
        else if (CoeurOn == true)
        {
            sr = CoeurRougeSprite;
        }
    }
}