using UnityEngine;

public class SpikeDetection : MonoBehaviour
{
    [SerializeField] private SceneGameManager _sceneGameManager;
    [SerializeField] private CounterScriptableObject _counterSO;

    public float restartDelay = 1f;
    [SerializeField] private GameObject _playerDeathPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.PlayerDieSFX);

            _counterSO.DeathCounter += 1;

            SpawnDeathEffect();
            Destroy(gameObject);

            _sceneGameManager.Restart(restartDelay);
        }
    }

    private void SpawnDeathEffect()
    {
        if (_playerDeathPrefab != null)
        {
            Instantiate(_playerDeathPrefab, transform.position, Quaternion.identity);
        }
    }
}
