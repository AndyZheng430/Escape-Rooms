using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCountdown : MonoBehaviour
{
    int CountdownStart = 5;
    // Start is called before the first frame update
    void Start()
    {
       countdownTimer(); 
    }

    void countdownTimer()
    {
        if(CountdownStart > 0)
        {
            CountdownStart--;
            Invoke("countdownTimer", 1.0f);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
