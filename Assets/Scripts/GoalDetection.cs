using UnityEngine;

public class GoalDetection : MonoBehaviour
{
    [SerializeField] private SceneGameManager _sceneGameManager;
    public float restartDelay = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            _sceneGameManager.ReachGoal();

            // SceneGameManager.Instance.Exit();
        }
    }
}
