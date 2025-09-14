using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PauseCanvasManager _pauseCanvasManager;

    private InputAction _pauseAction;
    private InputAction _moveAction;
    private InputAction _jumpAction;

    private bool _isPaused = false;

    private void Awake()
    {
        // Find actions
        var actions = _playerInput.actions;
        _pauseAction = actions.FindAction("Pause");
        _moveAction = actions.FindAction("Move");
        _jumpAction = actions.FindAction("Jump");

        if (_pauseAction != null)
            _pauseAction.performed += OnPauseToggle;
    }

    private void OnDestroy()
    {
        if (_pauseAction != null)
            _pauseAction.performed -= OnPauseToggle;
    }

    private void OnPauseToggle(InputAction.CallbackContext context)
    {
        if (_isPaused)
        {
            // Resume game
            _pauseCanvasManager.Resume();

            // Re-enable gameplay actions
            _moveAction?.Enable();
            _jumpAction?.Enable();

            _isPaused = false;
        }
        else
        {
            // Pause game
            _pauseCanvasManager.Pause();

            // Disable gameplay actions
            _moveAction?.Disable();
            _jumpAction?.Disable();

            _isPaused = true;
        }
    }
}
