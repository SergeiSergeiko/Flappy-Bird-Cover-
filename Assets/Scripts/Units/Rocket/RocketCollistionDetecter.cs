using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class RocketCollistionDetecter : MonoBehaviour
{
    [SerializeField] private Rocket _rocket;

    private int _damage = 1;

    private void OnValidate()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            _rocket.TakeDamage(_damage);
        }
    }
}