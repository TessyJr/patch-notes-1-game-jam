using UnityEngine;
using UnityEngine.SceneManagement;

public class ReachGoalCanvasManager : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] private GameObject _content;

    [Header("Sceene Settings")]
    [SerializeField] private string _mainMenuScene;

    public void OpenCanvas()
    {
        _content.SetActive(true);
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
