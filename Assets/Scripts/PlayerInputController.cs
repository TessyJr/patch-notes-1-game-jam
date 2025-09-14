using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PauseCanvasManager _pauseCanvasManager;

    private InputAction _pauseAction;

    private void Awake()
    {
        var actions = _playerInput.actions;
        _pauseAction = actions.FindAction("Pause");

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
        if (Time.timeScale == 0)
        {
            // Resume game
            _pauseCanvasManager.Resume();
        }
        else
        {
            // Pause game
            _pauseCanvasManager.Pause();
        }
    }
}
