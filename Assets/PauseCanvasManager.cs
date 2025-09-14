using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseCanvasManager : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] private GameObject _content;
    [SerializeField] private InputActionMap _playerInputActionMap;

    [Header("Sceene Settings")]
    [SerializeField] private string _mainMenuScene;

    public void OpenCanvas()
    {
        _content.SetActive(true);
    }

    public void Pause()
    {
        _playerInputActionMap.Disable();
        Time.timeScale = 0;
        _content.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        _content.SetActive(false);
        _playerInputActionMap.Enable();
    }

    public void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(_mainMenuScene);
    }
}
