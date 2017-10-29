using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Clock : MonoBehaviour {

    const float
         degreePerHour = 30f,
         degreePerMinute = 6f,
         degreePerSecond = 6f;


    public Transform hoursTransform, minutesTransform, secondsTransform;

    public bool continuous;

     void Update()
    {
        if (continuous)
        {
            UpdateContinuous();
        }
        else
        {
            UpdateDiscrete();
        }
    }

    void UpdateDiscrete ()
    {
        DateTime time = DateTime.Now;
        hoursTransform.localRotation = 
            Quaternion.Euler(0f, DateTime.Now.Hour * degreePerHour, 0f);
        minutesTransform.localRotation =
            Quaternion.Euler(0f, DateTime.Now.Minute * degreePerMinute, 0f);
        secondsTransform.localRotation =
            Quaternion.Euler(0f, DateTime.Now.Second * degreePerSecond, 0f);
    }

    void UpdateContinuous ()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hoursTransform.localRotation =
            Quaternion.Euler(0f, (float) time.TotalHours * degreePerHour, 0f);
        minutesTransform.localRotation =
            Quaternion.Euler(0f, (float) time.TotalMinutes * degreePerMinute, 0f);
        secondsTransform.localRotation =
            Quaternion.Euler(0f, (float) time.TotalSeconds * degreePerSecond, 0f);
    }
    
}
