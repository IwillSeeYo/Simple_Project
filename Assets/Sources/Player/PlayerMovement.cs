using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _maxSpeed = 10f;
    [SerializeField] private float _acceleration = 1f;


    private float _inputDirection;
    private Rigidbody _rigitbody;
    private PlayerInput _playerInput;

    private void Start()
    {
        _rigitbody= GetComponent<Rigidbody>();
        _playerInput= GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        _inputDirection = _playerInput.GetInputDirection();

        Vector3 movement = new Vector3(1f, 0, 0) * _inputDirection * _moveSpeed * Time.fixedDeltaTime;

        if (_rigitbody.velocity.magnitude < _maxSpeed)
            _rigitbody.AddForce(movement * _acceleration, ForceMode.Acceleration);

        _rigitbody.velocity = Vector3.ClampMagnitude(_rigitbody.velocity, _maxSpeed);
    }
}