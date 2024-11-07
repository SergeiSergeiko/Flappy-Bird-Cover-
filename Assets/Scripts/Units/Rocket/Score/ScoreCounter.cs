using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score;

    public event Action<int> ScoreChanged;

    private float _timePerScore = 1f;
    private float _passedTime = 0f;

    public void Reset()
    {
        int defaultValue = 0;

        SetScore(defaultValue);
    }

    private void Start()
    {
        SetScore(0);
    }

    private void Update()
    {
        AddScoreEveryTime();
    }

    private void AddScoreEveryTime()
    {
        _passedTime += Time.deltaTime;

        if (_passedTime >= _timePerScore)
        {
            SetScore(++_score);
            _passedTime = 0f;
        }
    }

    private void SetScore(int value)
    {
         _score = value;
        ScoreChanged?.Invoke(_score);
    }
}