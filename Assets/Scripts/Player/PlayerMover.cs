using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private SIDE _side = SIDE.Mid;
    [SerializeField] private float _currentSpeed;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _lineDistance;

    private const float _maxSpeed = 100;
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
        
        if (_side == SIDE.Left)
        {
            Sidestep(-_lineDistance);
        }
        else if (_side == SIDE.Right)
        {
            Sidestep(_lineDistance);
        }
        
        Vector3 difference = _targetPosition - transform.position;
        Vector3 moveDirection = difference.normalized * 25 * Time.deltaTime;

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
            if (_side == SIDE.Mid)
            {
                LeftTurn?.Invoke();
                _side = SIDE.Left;
            }
            else if (_side == SIDE.Right)
            {
                LeftTurn?.Invoke();
                _side = SIDE.Mid;
            }
        }

        if (goingRight)
        {
            if (_side == SIDE.Mid)
            {
                RightTurn?.Invoke();
                _side = SIDE.Right;
            }
            else if (_side == SIDE.Left)
            {
                RightTurn?.Invoke();
                _side = SIDE.Mid;
            }
        }
    }

    private void Sidestep(float lineDistance)
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
        Ray groundRay = new Ray(new Vector3(_controller.bounds.center.x, (_controller.bounds.center.y - _controller.bounds.extents.y) + 0.2f, _controller.bounds.center.z), Vector3.down);

        return Physics.Raycast(groundRay, 0.2f + 0.1f);
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
            _currentSpeed += 1;
            StartCoroutine(SpeedIncrease());
        }
    }
}

public enum SIDE
{
    Left,
    Mid,
    Right
}