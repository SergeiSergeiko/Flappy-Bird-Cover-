using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RocketMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Vector3 _startPosition;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private Rigidbody2D _rigidbody;
    private bool _isButtonJumpPressed;

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody.velocity = Vector2.zero;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _startPosition = transform.position;

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        Reset();
    }

    private void FixedUpdate()
    {
        if (_isButtonJumpPressed)
            Jump();

        Rotate();
    }

    public void OnButtonJumpPressed()
    {
        _isButtonJumpPressed = true;
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_speed, _tapForce);
        transform.rotation = _maxRotation;

        _isButtonJumpPressed = false;
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Lerp
            (transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }
}