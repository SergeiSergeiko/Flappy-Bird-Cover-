using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class BulletCollisionDetecter : MonoBehaviour
{
    [SerializeField] protected Bullet _bullet;

    private void OnValidate()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Destroyer _))
            _bullet.Remove();
    }
}