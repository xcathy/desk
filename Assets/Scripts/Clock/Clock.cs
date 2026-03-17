using UnityEngine;
using TMPro;
using System;

public class Clock : MonoBehaviour
{
    public TMP_Text timeDisplay;
    private string time;
    private DateTime currTime;

    void Start()
    {
        // initialize date time
        currTime = DateTime.Now;
    }

    void FixedUpdate()
    {
        currTime = DateTime.Now;
        string newTimeDisplay = currTime.ToString("HH:mm");

        // set the time to new time if the new time is different from the old time
        if (newTimeDisplay != timeDisplay.text) timeDisplay.text = newTimeDisplay;
    }
}
