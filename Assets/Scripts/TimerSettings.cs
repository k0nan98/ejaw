using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newTimerData", menuName = "TimerData", order = 52)]
public class TimerSettings : ScriptableObject
{
    [SerializeField]
    private float timer;

    public float GetTimer()
    {
        return timer;
    }
}
