using UnityEngine;

public class SmallEnemyBulletCollisionDetecter : BulletCollisionDetecter
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.TryGetComponent(out Rocket rocket))
        {
            rocket.TakeDamage(_bullet.Damage);
            _bullet.Remove();
        }    
    }
}