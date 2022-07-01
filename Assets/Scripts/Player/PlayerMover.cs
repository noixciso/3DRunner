using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Side _side = Side.Mid;
    [SerializeField] private float _currentSpeed;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _lineDistance;

    private const float _maxSpeed = 100;
    private const float _lineShiftSpeed = 25;
    private const float _currentSpeedIncrease = 1;
    private CharacterController _controller;
    private Vector3 _direction;
    private Vector3 _targetPosition;

    public event UnityAction Jumping;
    public event UnityAction Running;
    public event UnityAction LeftTurn;
    public event UnityAction RightTurn;
    public event UnityAction FastFalling;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _targetPosition = transform.position;

        RunSpeedIncrease();
    }

    private void Update()
    {
        _targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        
        if (_side == Side.Left)
        {
            StepAside(-_lineDistance);
        }
        else if (_side == Side.Right)
        {
            StepAside(_lineDistance);
        }
        
        Vector3 difference = _targetPosition - transform.position;
        Vector3 moveDirection = difference.normalized * _lineShiftSpeed * Time.deltaTime;

        if (moveDirection.sqrMagnitude < difference.sqrMagnitude)
        {
            _controller.Move(moveDirection);
        }
    }

    private void FixedUpdate()
    {
        Run();
    }

    public void MoveSideways(bool goingRight)
    {
        if (!goingRight)
        {
            if (_side == Side.Mid)
            {
                LeftTurn?.Invoke();
                _side = Side.Left;
            }
            else if (_side == Side.Right)
            {
                LeftTurn?.Invoke();
                _side = Side.Mid;
            }
        }

        if (goingRight)
        {
            if (_side == Side.Mid)
            {
                RightTurn?.Invoke();
                _side = Side.Right;
            }
            else if (_side == Side.Left)
            {
                RightTurn?.Invoke();
                _side = Side.Mid;
            }
        }
    }

    private void StepAside(float lineDistance)
    {
        _targetPosition = new Vector3(_targetPosition.x + lineDistance, transform.position.y, transform.position.z);
    }

    public void Jump()
    {
        Jumping?.Invoke();
        _direction.y = _jumpForce;
    }

    public void FallQuickly()
    {
        FastFalling?.Invoke();
        _direction.y = -_jumpForce;
    }

    private void Run()
    {
        Running?.Invoke();
        _direction.z = _currentSpeed;
        _direction.y += _gravity * Time.fixedDeltaTime;
        _controller.Move(_direction * Time.fixedDeltaTime);
    }

    public bool IsGrounded()
    {
        float maxRayDistance = 0.3f;
        Ray groundRay = new Ray(new Vector3(_controller.bounds.center.x, (_controller.bounds.center.y - _controller.bounds.extents.y) + 0.2f, _controller.bounds.center.z), Vector3.down);
        
        return Physics.Raycast(groundRay, maxRayDistance);
    }

    public void RunSpeedIncrease()
    {
        StartCoroutine(SpeedIncrease());
    }

    private IEnumerator SpeedIncrease()
    {
        yield return new WaitForSeconds(1);
        
        if (_currentSpeed < _maxSpeed)
        {
            _currentSpeed += _currentSpeedIncrease;
            StartCoroutine(SpeedIncrease());
        }
    }
}

public enum Side
{
    Left,
    Mid,
    Right
}