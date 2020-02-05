using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int scoreValue;
    Text score;
    public static int scoreKills;
    public static int fermePorte;
    public static int clouPorte;
    
      
    public int minTimeSpawn;
    public int maxTimeSpawn;
    private float cooldown;

    void Start()
    {
        clouPorte = 0;
        fermePorte = 0;
        scoreKills = 0;
        score = GetComponent<Text>();
        scoreValue = 0;
        minTimeSpawn = 5;
        maxTimeSpawn = 13;
        cooldown = 0;
        PlayerPrefs.SetInt("scoreTotal", 0);
   
    }


    void Update()
    {
        scoreValue = CalculScores.scoreParSecondes + CalculScores.score5Secondes + scoreKills + fermePorte;
        score.text = "Score = " + scoreValue;
        PlayerPrefs.SetInt("scoreTotal", scoreValue);

        
        if ( scoreValue >= 15000 && scoreValue <= 15300 && cooldown <= Time.time)
        {
            maxTimeSpawn = maxTimeSpawn - 2;
            cooldown = Time.time + 30;
        }

        if (scoreValue >= 30000 && scoreValue <= 30300 && cooldown <= Time.time)
        {
            minTimeSpawn = minTimeSpawn - 1;
            maxTimeSpawn = maxTimeSpawn - 1;
            cooldown = Time.time + 30;
        }

        if (scoreValue >= 55000 && scoreValue <= 55300 && cooldown <= Time.time)
        {            
            maxTimeSpawn = maxTimeSpawn - 2;
            cooldown = Time.time + 30;
        }

        if (scoreValue >= 70000 && scoreValue <= 70300 && cooldown <= Time.time)
        {
            minTimeSpawn = minTimeSpawn - 1;
            cooldown = Time.time + 30;
        }

        if (scoreValue >= 90000 && scoreValue <= 90300 && cooldown <= Time.time)
        {
            minTimeSpawn = minTimeSpawn - 1;
            maxTimeSpawn = maxTimeSpawn - 2;
            cooldown = Time.time + 30;
        }

    }

}
