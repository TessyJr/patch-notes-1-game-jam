using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private static WaitForSeconds _waitForSeconds1 = new WaitForSeconds(0.6f);

    [Header("Movement Settings")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _movementSpeed = 4f;
    [SerializeField] private float _jumpForce = 8f;
    [SerializeField] private float _friction = 0f;

    [Header("Ground Checker Settings")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius = 0.4f;
    [SerializeField] private LayerMask _groundLayer;

    [Header("Wall Checker Settings")]
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private float _wallCheckRadius = 0.6f;
    [SerializeField] private LayerMask _wallLayer;

    [Header("Scriptable Object Settings")]
    [SerializeField] private PlayerSettingScriptableObject _playerSettingSO;

    private Vector2 _moveDirection;
    private bool _isGrounded;
    private bool _wasGrounded;
    private bool _isStickToWall;
    private Vector2 _externalForce;
    private float _originalMovementSpeed;

    public bool IsGrounded => _isGrounded;
    public Vector2 Velocity => _rb.velocity;
    public bool IsStickToWall => _isStickToWall;
    public bool IsMoving => Mathf.Abs(_moveDirection.x) > 0.1f;

    void Awake()
    {
        _originalMovementSpeed = _movementSpeed;
    }

    void Update()
    {
        _isStickToWall = Physics2D.OverlapCircle(_wallCheck.position, _wallCheckRadius, _wallLayer);

        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);

        _wasGrounded = _isGrounded;
    }

    private void FixedUpdate()
    {
        // Apply friction only on ground
        float effectiveSpeed = _movementSpeed;
        if (_isGrounded && _friction > 0f)
        {
            effectiveSpeed *= (1f - _friction); // reduce speed by friction %
        }

        // Apply movement
        Vector2 move = _moveDirection * effectiveSpeed;
        _rb.velocity = new Vector2(move.x + _externalForce.x, _rb.velocity.y);
        _externalForce = Vector2.zero;

        // SpeedDemon mechanic
        if (_rb.velocity.x != 0 && _playerSettingSO.SpeedDemon)
        {
            _movementSpeed += 0.15f;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (_playerSettingSO.InputLag)
        {
            StartCoroutine(DelayedMove(context));
        }
        else
        {
            _moveDirection = context.ReadValue<Vector2>();
        }
    }

    private IEnumerator DelayedMove(InputAction.CallbackContext context)
    {
        yield return _waitForSeconds1;
        _moveDirection = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_playerSettingSO.InputLag)
            {
                StartCoroutine(DelayedJump());
            }
            else if (CanJump())
            {
                Jump();
            }
        }
    }

    private IEnumerator DelayedJump()
    {
        yield return _waitForSeconds1;
        if (CanJump())
        {
            Jump();
        }
    }

    private void Jump()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.PlayerJumpSFX);
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private bool CanJump()
    {
        return _isGrounded || _playerSettingSO.WhatIsGround;
    }

    public void SetFriction(float friction) => _friction = friction;
    public float GetMovementSpeed() => _movementSpeed;
}
