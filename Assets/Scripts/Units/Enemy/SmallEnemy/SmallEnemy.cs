using System;
using UnityEngine;

public class SmallEnemy : Enemy
{
    [SerializeField] private SmallEnemyAttacker _attacker;

    public event Action<Vector2> Attacked;

    private void OnEnable()
    {
        _attacker.Attacked += OnAttackedHandler;
    }

    private void OnDisable()
    {
        _attacker.Attacked -= OnAttackedHandler;
    }

    private void OnAttackedHandler()
    {
        Attacked?.Invoke(_attacker.transform.position);
    }
}