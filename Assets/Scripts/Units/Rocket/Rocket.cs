using System;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private UserInput _input;
    [SerializeField] private RocketMover _mover;

    public event Action Died;

    public void Reset()
    {
        _mover.Reset();
        _scoreCounter.Reset();
        _health.Reset();
        _input.enabled = true;
    }

    private void OnEnable()
    {
        _health.Dying += Die;
    }

    private void OnDisable()
    {
        _health.Dying -= Die;
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    public void DisableInput()
    {
        _input.enabled = false;
    }

    private void Die()
    {
        Died?.Invoke();
    }
}