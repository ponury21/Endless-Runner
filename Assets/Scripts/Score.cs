using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Transform player;
    public Text scoreText;
    public float currentScore;


   
    // Update is called once per frame
    void Update()
    {
        currentScore = Mathf.Abs(player.position.z - 104);
        scoreText.text =  currentScore.ToString("0");
    }

    
}
