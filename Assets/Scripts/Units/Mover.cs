using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _diractionX;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 diraction = new(_diractionX, 0);

        _rigidbody.position += diraction * (_speed * Time.deltaTime);
    }
}