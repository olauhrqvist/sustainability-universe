using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
public class ClockScript : MonoBehaviour
{
    private Text textClock;
    public float seconds, minutes;


    void Awake()
    {
        textClock = GetComponent<Text>();
    }


    void Update()
    {
        minutes = (int)(Time.time / 60f);
        seconds = (int)(Time.time % 60f);
        textClock.text = minutes.ToString("00") + ":" + seconds.ToString("00");

    }
}