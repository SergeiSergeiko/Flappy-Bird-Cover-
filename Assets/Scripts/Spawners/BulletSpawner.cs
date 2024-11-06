using UnityEngine;

public class BulletSpawner : GenericSpawner<Bullet>
{
    public void OnOwnerAttackedHandler(Vector2 position)
    {
        Spawn(position);
    }

    protected override void Subscribe(Bullet bullet)
    {
        bullet.Removing += OnBulletCollidedHandler;
    }

    private void OnBulletCollidedHandler(Bullet bullet)
    {
        bullet.Removing -= OnBulletCollidedHandler;

        Pool.Release(bullet);
    }
}