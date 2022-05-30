using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _currentSpeed;
    [SerializeField] private int _lineDistance;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravity;

    private CharacterController _controller;
    private Vector3 _direction;
    private int _lineToMove = 1;
    private float _maxSpeed = 100;

    public event UnityAction Jumping;
    public event UnityAction Running;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        StartCoroutine(SpeedIncrement());
    }

    private void Update()
    {
        if (SwipeController.swipeRight)
        {
            if (_lineToMove < 2)
            {
                _lineToMove++;
            }
        }

        if (SwipeController.swipeLeft)
        {
            if (_lineToMove > 0)
            {
                _lineToMove--;
            }
        }

        if (SwipeController.swipeUp)
        {
            if (_controller.isGrounded)
            {
                Jump();
            }
        }
        
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        
        if (_lineToMove == 0)
        {
            targetPosition += Vector3.left * _lineDistance;
        }
        else if (_lineToMove == 2)
        {
            targetPosition += Vector3.right * _lineDistance;
        }

        //плавное передвижение и столкновение с преградами
        if (transform.position == targetPosition)
        {
            return;
        }

        Vector3 difference = targetPosition - transform.position;
        Vector3 moveDirection = difference.normalized * 25 * Time.deltaTime;
        
        if (moveDirection.sqrMagnitude < difference.sqrMagnitude)
        {
            _controller.Move(moveDirection);
        }
        else
        {
            _controller.Move(difference);
        }
    }
    
    private void FixedUpdate()
    {
        Run();
    }

    private void Run()
    {
        Running?.Invoke();
        _direction.z = _currentSpeed;
        _direction.y += _gravity * Time.fixedDeltaTime;
        _controller.Move(_direction * Time.fixedDeltaTime);
    }
    
    private void Jump()
    {
        _direction.y = _jumpForce;
        Jumping?.Invoke();
        
    }

    private IEnumerator SpeedIncrement()
    {
        yield return new WaitForSeconds(1);
        if (_currentSpeed < _maxSpeed)
        {
            _currentSpeed += 1;
            StartCoroutine(SpeedIncrement());
        }
    }
}
