using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private static WaitForSeconds _waitForSeconds1 = new WaitForSeconds(0.6f);
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _movementSpeed = 4f;
    [SerializeField] private float _jumpForce = 8f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius = 0.4f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private PlayerSettingScriptableObject _playerSettingSO;

    private Vector2 _moveDirection;
    private bool _isGrounded;
    private bool _wasGrounded;
    private Vector2 _externalForce;
    private float _originalMovementSpeed;

    public bool IsGrounded => _isGrounded;
    public Vector2 Velocity => _rb.velocity;
    public bool IsMoving => Mathf.Abs(_moveDirection.x) > 0.1f;

    void Awake()
    {
        _originalMovementSpeed = _movementSpeed;
    }

    void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);

        // detect landing
        if (_isGrounded && !_wasGrounded)
        {
            RestoreMovementSpeed();
        }

        _wasGrounded = _isGrounded;
    }

    private void FixedUpdate()
    {
        Vector2 move = _moveDirection * _movementSpeed;
        _rb.velocity = new Vector2(move.x + _externalForce.x, _rb.velocity.y);
        _externalForce = Vector2.zero;

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
        // cache speed before modifying
        _originalMovementSpeed = _movementSpeed;

        // force jump speed
        _movementSpeed = 4f;

        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void RestoreMovementSpeed()
    {
        // restore speed only if it was changed
        if (_movementSpeed == 4f)
        {
            _movementSpeed = _originalMovementSpeed;
        }
    }

    private bool CanJump()
    {
        return _isGrounded || _playerSettingSO.WhatIsGround;
    }

    public void SetMovementSpeed(float movementSpeed) => _movementSpeed = movementSpeed;
}
