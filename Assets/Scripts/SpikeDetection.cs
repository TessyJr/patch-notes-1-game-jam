using UnityEngine;

public class SpikeDetection : MonoBehaviour
{
    [SerializeField] private SceneGameManager _sceneGameManager;

    public float restartDelay = 1f;
    [SerializeField] private GameObject _playerDeathPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            SpawnDeathEffect();
            Destroy(gameObject);

            _sceneGameManager.Restart(restartDelay);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trap"))
        {
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
