using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Countdown
{

    public float TimeLeft { get; set; }
    public bool IsStopped {get; private set;}

    public string TextTime {
        get
        {
            return string.Format("{0:0}:{1:00}", minutes, seconds);
        }
    }

    private float minutes;
    private float seconds;


    public Countdown(float startTime)
    {
        TimeLeft = startTime;
        IsStopped = true;
    }

    public void Start()
    {
        IsStopped = false;
        Update();
        //StartCoroutine(updateCoroutine());
    }

    public void Stop()
    {
        IsStopped = true;
        Update();
    }

    public void Update()
    {
        if (IsStopped) return;
        TimeLeft -= Time.deltaTime;

        minutes = Mathf.Floor(TimeLeft / 60);
        seconds = TimeLeft % 60;
        if (seconds > 59) seconds = 59;
        if (minutes < 0)
        {
            IsStopped = true;
            minutes = 0;
            seconds = 0;
        }
    }
}