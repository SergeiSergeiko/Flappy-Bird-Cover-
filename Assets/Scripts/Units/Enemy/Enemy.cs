using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _health;

    public event Action<Enemy> Died;

    [field: SerializeField] public int Reward;

    private void OnDisable()
    {
        _health.Dying -= Die;
    }

    private void Start()
    {
        _health.Dying += Die;
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    public void Remove()
    {
        Die();
    }

    private void Die()
    {
        Died?.Invoke(this);
    }
}