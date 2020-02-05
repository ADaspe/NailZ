using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculScores : MonoBehaviour
{
    public static int scoreParSecondes;
    public static int score5Secondes;
    private float countDown1Seconde;
    private float countDown5Secondes;
    private Door Porte;

    void Start()
    {
        score5Secondes = 0;
        scoreParSecondes = 0;

    }

    void Update()
    {
        if (countDown1Seconde <= Time.time)
        {
            scoreParSecondes = scoreParSecondes + 50;
            countDown1Seconde = Time.time + 1;
        }


        if (countDown5Secondes <= Time.time)
        {
            score5Secondes = score5Secondes + 100;
            countDown5Secondes = Time.time + 5;
        }
    }
}
