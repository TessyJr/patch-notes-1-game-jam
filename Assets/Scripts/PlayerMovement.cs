using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private static WaitForSeconds _waitForSeconds1 = new WaitForSeconds(0.6f);
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private PlayerSettingScriptableObject _playerSettingSO;

    private Vector2 _moveDirection;
    private bool _isGrounded;
    private Vector2 _externalForce;

    public bool IsGrounded => _isGrounded;
    public Vector2 Velocity => _rb.velocity;
    public bool IsMoving => Mathf.Abs(_moveDirection.x) > 0.1f;

    void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
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
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private bool CanJump()
    {
        return _isGrounded || _playerSettingSO.WhatIsGround;
    }
}