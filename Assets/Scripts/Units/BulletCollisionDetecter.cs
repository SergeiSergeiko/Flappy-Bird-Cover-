using System;
using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class BulletCollisionDetecter : MonoBehaviour
{
    public event Action Collided;

    [field: SerializeField] public Bullet Bullet { get; private set; }

    private void OnEnable()
    {
        Collided += Bullet.OnCollidedHandler;
    }

    private void OnDisable()
    {
        Collided -= Bullet.OnCollidedHandler;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Destroyer _))
            TriggerCollidedEvent();
    }

    protected void TriggerCollidedEvent()
    {
        Collided?.Invoke();
    }
}