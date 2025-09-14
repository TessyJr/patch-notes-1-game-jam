using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseCanvasManager : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] private GameObject _content;
    [SerializeField] private PlayerInput _playerInput;

    [Header("Sceene Settings")]
    [SerializeField] private string _mainMenuScene;

    private InputAction _moveAction;
    private InputAction _jumpAction;

    private void Awake()
    {
        var actions = _playerInput.actions;
        _moveAction = actions.FindAction("Move");
        _jumpAction = actions.FindAction("Jump");
    }

    public void Pause()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.UISFX);

        Time.timeScale = 0;
        _moveAction?.Disable();
        _jumpAction?.Disable();
        _content.SetActive(true);
    }

    public void Resume()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.UISFX);

        Time.timeScale = 1;
        _moveAction?.Enable();
        _jumpAction?.Enable();
        _content.SetActive(false);
    }

    public void Restart()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.UISFX);

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void BackToMainMenu()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.UISFX);
        SceneManager.LoadScene(_mainMenuScene);
    }
}
