using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private CounterScriptableObject _counterSO;
    [SerializeField] private bool _resetCounter = false;
    
    public void LoadScene(string sceneName)
    {
        if (_resetCounter && _counterSO) _counterSO.Initialize();

        SceneManager.LoadScene(sceneName);
    }
}
