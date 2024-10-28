using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnDisable()
    {
        _health.Dies -= Die;
    }

    private void Start()
    {
        _health.Dies += Die;
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}