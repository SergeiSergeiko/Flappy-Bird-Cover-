using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score;

    public event Action<int> ScoreChanged;

    public void Add()
    {
        SetScore(_score++);
    }

    public void Reset()
    {
        int defaultValue = 0;

        SetScore(defaultValue);
    }

    private void SetScore(int value)
    {
        _score = value;
        ScoreChanged?.Invoke(_score);
    }
}