using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endscore : MonoBehaviour
{
    private int score;
    Text scoreText;
    public ScoreScript score2;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        score = PlayerPrefs.GetInt("scoreTotal");
        scoreText.text = "Score : " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}