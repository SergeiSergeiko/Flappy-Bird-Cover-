using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RocketMover : MonoBehaviour
{
    [SerializeField] private UserInput _input;

    [Space]
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce;

    private Rigidbody2D _rigidbody;
    private bool _isButtonJumpPressed;

    private void OnEnable()
    {
        _input.ButtonJumpPressed += OnButtonJumpPressed;
    }

    private void OnDisable()
    {
        _input.ButtonJumpPressed -= OnButtonJumpPressed;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_isButtonJumpPressed)
            Move();
    }

    private void OnButtonJumpPressed()
    {
        _isButtonJumpPressed = true;
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(_speed, _tapForce);

        _isButtonJumpPressed = false;
    }
}
