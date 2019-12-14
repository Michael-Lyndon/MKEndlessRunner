using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemScore : MonoBehaviour
{
    public int itemScoreValue;
    private scoreManager scoreManager;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<scoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player"){
            scoreManager.addScore(itemScoreValue);
            this.gameObject.SetActive(false);
        }
    }
}
