using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _mover.MoveSideways(false);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _mover.MoveSideways(true);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (_mover.IsGrounded())
            {
                _mover.Jump();
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (_mover.IsGrounded() == false)
            {
                _mover.FallQuickly();
            }
        }
    }
}
