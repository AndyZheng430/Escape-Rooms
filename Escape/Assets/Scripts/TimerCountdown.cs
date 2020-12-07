using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerCountdown : MonoBehaviour
{
    int CountdownStart = 300;
    public Text UITimer; 
    // Start is called before the first frame update
    void Start()
    {
       countdownTimer(); 
    }

    void countdownTimer()
    {
        if(CountdownStart > 0)
        {
            TimeSpan countdownInMinutes = TimeSpan.FromSeconds(CountdownStart);
            UITimer.text = "Timer: " + countdownInMinutes.Minutes + ":" + countdownInMinutes.Seconds;
            CountdownStart--;
            Invoke("countdownTimer", 1.0f);
        }
        else
        {
            UITimer.text= "Game Over!";
            SceneManager.LoadScene(0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
