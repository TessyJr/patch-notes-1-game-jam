using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private PlayerMovement _movement;

    private bool _wasGrounded = false;
    private bool _facingRight = true;

    void Update()
    {
        if (_movement.Velocity.x > 0.1f)
        {
            _facingRight = true;
        }
        else if (_movement.Velocity.x < -0.1f)
        {
            _facingRight = false;
        }

        _sprite.flipX = !_facingRight;

        // Running
        _animator.SetBool("IsRunning", _movement.IsMoving && _movement.IsGrounded);

        // Falling
        bool isFalling = !_movement.IsGrounded && _movement.Velocity.y < -0.1f;
        _animator.SetBool("IsFalling", isFalling);

        // Jump trigger
        if (_wasGrounded && _movement.Velocity.y > 0.1f)
        {
            _animator.SetTrigger("Jump");
        }

        _wasGrounded = _movement.IsGrounded;
    }
}