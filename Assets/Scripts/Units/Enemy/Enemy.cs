using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _health;

    public event Action<Enemy> Died;

    private void OnDisable()
    {
        _health.Dies -= Die;
    }

    private void Start()
    {
        _health.Dies += Die;
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    private void Die()
    {
        Died?.Invoke(this);
    }
}