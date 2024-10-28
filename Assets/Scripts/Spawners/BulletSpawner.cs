using System;
using UnityEngine;

public class BulletSpawner : GSpawner<Bullet>
{
    public void OnOwnerAttackedHandler(Vector2 position)
    {
        Spawn(position);
    }

    protected override void Subscribe(Bullet bullet)
    {
        bullet.Collided += OnBulletCollidedHandler;
    }

    private void OnBulletCollidedHandler(Bullet bullet)
    {
        bullet.Collided -= OnBulletCollidedHandler;

        Pool.Release(bullet);
    }
}