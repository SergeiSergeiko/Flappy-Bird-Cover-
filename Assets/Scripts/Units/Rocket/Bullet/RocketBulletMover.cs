using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class RocketBulletMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody.position += Vector2.right * (_speed * Time.deltaTime);
    }
}