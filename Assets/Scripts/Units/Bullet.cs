using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _dieDelay;

    public event Action<Bullet> Removing;

    [field: SerializeField] public int Damage { get; private set; }

    private Timer _timer = new();
    private Coroutine _countdownTime;

    private void OnEnable()
    {
        _countdownTime = StartCoroutine(_timer.CountdownTime(_dieDelay, OnTimeIsUp));
    }

    private void OnDisable()
    {
        if (_countdownTime != null)
            StopCoroutine(_countdownTime);
    }

    private void OnTimeIsUp()
    {
        Remove();
    }

    public void Remove()
    {
        Removing?.Invoke(this);
    }
}