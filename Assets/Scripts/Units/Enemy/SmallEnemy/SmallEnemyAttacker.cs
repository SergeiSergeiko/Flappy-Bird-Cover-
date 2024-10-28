using System;
using System.Collections;
using UnityEngine;

public class SmallEnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _delay;

    public event Action Attacked;

    private bool _attacks = true;
    private Coroutine _attacking;

    private void OnEnable()
    {
        StartAttacking();
    }

    private void OnDisable()
    {
        if (_attacking != null)
            StopCoroutine(_attacking);
    }

    private IEnumerator Attacking()
    {
        WaitForSeconds wait = new(_delay);

        while (_attacks)
        {
            Attacked?.Invoke();

            yield return wait;
        }
    }

    private void StartAttacking()
    {
        if (_attacking != null)
            StopCoroutine(_attacking);

        _attacking = StartCoroutine(Attacking());
    }
}