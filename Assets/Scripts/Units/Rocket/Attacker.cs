using System;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private AudioSource _audioShot;

    public event Action<Vector2> Attacked;

    private void OnEnable()
    {
        Attacked += _bulletSpawner.OnOwnerAttackedHandler;
    }

    private void OnDisable()
    {
        Attacked -= _bulletSpawner.OnOwnerAttackedHandler;
    }

    public void Attack()
    {
        _audioShot.PlayOneShot(_audioShot.clip);
        Attacked?.Invoke(transform.position);
    }
}