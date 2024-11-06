using UnityEngine;

public class RocketBulletCollisionDetecter : BulletCollisionDetecter
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_bullet.Damage);
            _bullet.Remove();
        }
    }
}