using System;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private UserInput _input;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private AudioSource _audioShot;

    public event Action<Vector2> Attacked;

    private void OnDisable()
    {
        _input.ButtonAttackPressed -= Attack;
        Attacked -= _bulletSpawner.OnOwnerAttackedHandler;
    }

    private void Start()
    {
        _input.ButtonAttackPressed += Attack;
        Attacked += _bulletSpawner.OnOwnerAttackedHandler;
    }

    private void Attack()
    {
        _audioShot.PlayOneShot(_audioShot.clip);
        Attacked?.Invoke(transform.position);
    }
}