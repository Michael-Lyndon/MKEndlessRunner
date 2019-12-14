using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{

    public Text scoreText;

    public float scoreValue;
    public float scoreRate; //the rate at which points are gained over time
    public bool canScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canScore){
            scoreValue += scoreRate * Time.deltaTime;
            scoreText.text = "Score: " + Mathf.Round(scoreValue);
        }
    }

    public void resetScore(){
        scoreValue = 0;
    }
}
