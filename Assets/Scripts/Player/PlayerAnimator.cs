using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private PlayerMover _playerMover;

    private void OnEnable()
    {
        _playerMover.Jumping += OnJump;
        _playerMover.Running += OnRun;
    }

    private void OnDisable()
    {
        _playerMover.Jumping -= OnJump;
        _playerMover.Running -= OnRun;

    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnJump()
    {
        _animator.SetTrigger(States.Jump);
    }

    private void OnRun()
    {
        _animator.SetTrigger(States.isRunning);
    }
}

public static class States
{
    public const string isRunning = nameof(isRunning);
    public const string Jump = nameof(Jump);
}