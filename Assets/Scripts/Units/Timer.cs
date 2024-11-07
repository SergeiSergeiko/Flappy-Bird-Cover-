using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    private event Action TimeIsUp;

    public IEnumerator CountdownTime(float time, Action onTimerIsUp)
    {
        float passedTime = 0;
        TimeIsUp += onTimerIsUp;

        while (passedTime < time)
        {
            passedTime += Time.deltaTime;

            yield return null;
        }

        TimeIsUp?.Invoke();
        TimeIsUp -= onTimerIsUp;
    }
}