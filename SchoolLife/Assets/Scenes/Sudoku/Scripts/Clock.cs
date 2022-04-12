using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Clock : MonoBehaviour
{
    private int hour_ = 0;
    private int minute_ = 0;
    private int seconds_ = 0;

    private Text textClock;
    private float delta_time;
    private bool stop_clock_ = false;

    public static Clock Instance;
    public TimeSpan span;

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;

        textClock = GetComponent<Text>();
        delta_time = 0;
    }

    void Start()
    {
        stop_clock_ = false;
    }

    void Update()
    {
        if (GameSettings.Instance.GetPaused() == false && stop_clock_ == false)
        {
            delta_time += Time.deltaTime;
            span = TimeSpan.FromSeconds(delta_time);
            string minute = LeadingZero(span.Minutes);
            string seconds = LeadingZero(span.Seconds);

            textClock.text = minute + ":" + seconds;
        }
    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
    
    public void OnGameOver()
    {
        stop_clock_ = true;
    }

    private void OnEnable()
    {
        GameEvents.OnGameOver += OnGameOver;
    }

    private void OnDisable()
    {
        GameEvents.OnGameOver -= OnGameOver;
    }

    public Text GetCurrentTimeText()
    {
        return textClock;
    }
}
