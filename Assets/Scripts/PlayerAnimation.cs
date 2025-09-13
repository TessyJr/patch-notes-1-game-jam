using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private PlayerMovement _movement;

    private bool _wasGrounded = false;

    void Update()
    {
        _sprite.flipX = _movement.Velocity.x < -0.1f;

        _animator.SetBool("IsRunning", _movement.IsMoving && _movement.IsGrounded);

        bool isFalling = !_movement.IsGrounded && _movement.Velocity.y < -0.1f;

        _animator.SetBool("IsFalling", isFalling);

        if (_wasGrounded && _movement.Velocity.y > 0.1f)
        {
            _animator.SetTrigger("Jump");
        }

        _wasGrounded = _movement.IsGrounded;
    }
}
