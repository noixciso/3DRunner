using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;

    private Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _mover.Jumping += OnJump;
        _mover.Running += OnRun;
        _mover.RightTurn += OnRightTurn;
        _mover.LeftTurn += OnLeftTurn;
        _mover.FastFalling += OnFallQuickly;
    }

    private void OnDisable()
    {
        _mover.Jumping -= OnJump;
        _mover.Running -= OnRun;
        _mover.RightTurn -= OnRightTurn;
        _mover.LeftTurn -= OnLeftTurn;
        _mover.FastFalling -= OnFallQuickly;
    }

    private void OnJump()
    {
        _animator.SetTrigger(States.Jump);
    }

    private void OnRun()
    {
        _animator.SetBool(States.isRunning, true);
    }

    private void OnRightTurn()
    {
        _animator.SetTrigger(States.RightTurn);
    }
    
    private void OnLeftTurn()
    {
        _animator.SetTrigger(States.LeftTurn);
    }

    private void OnFallQuickly()
    {
        _animator.SetTrigger(States.FastFalling);
    }
}

public static class States
{
    public const string isRunning = nameof(isRunning);
    public const string Jump = nameof(Jump);
    public const string RightTurn = nameof(RightTurn);
    public const string LeftTurn = nameof(LeftTurn);
    public const string FastFalling = nameof(FastFalling);
}