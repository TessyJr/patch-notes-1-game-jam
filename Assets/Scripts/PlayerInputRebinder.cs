using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputRebinder : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInputComponent; // the one on your player
    [SerializeField] private PlayerSettingScriptableObject _playerSettingSO;

    private InputAction _moveAction;
    private InputAction _jumpAction;

    private void Awake()
    {
        // Get the actions directly from the PlayerInput component
        var actions = _playerInputComponent.actions;
        _moveAction = actions.FindAction("Move");
        _jumpAction = actions.FindAction("Jump");
    }

    private void Start()
    {
        if (_playerSettingSO.BrokenControl)
            ApplyBrokenBindings();
    }

    private void ApplyBrokenBindings()
    {
        _moveAction.RemoveAllBindingOverrides();
        _jumpAction.RemoveAllBindingOverrides();

        _moveAction.ApplyBindingOverride(2, "<Keyboard>/space"); // right -> space
        _moveAction.ApplyBindingOverride(1, "<Keyboard>/d");     // left -> d
        _jumpAction.ApplyBindingOverride("<Keyboard>/a");        // jump -> a
    }
}