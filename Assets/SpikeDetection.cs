using UnityEngine;

public class SpikeDetection : MonoBehaviour
{
    public float restartDelay = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Destroy(gameObject);

            GameSceneManager.Instance.Restart(restartDelay);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trap"))
        {
            Destroy(gameObject);

            GameSceneManager.Instance.Restart(restartDelay);
        }
    }
}
