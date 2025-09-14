using UnityEngine;
using UnityEngine.InputSystem;

public class GoalDetection : MonoBehaviour
{
    [SerializeField] private ReachGoalCanvasManager _reachGoalCanvasManager;
    [SerializeField] private SceneGameManager _sceneGameManager;
    [SerializeField] private PlayerInput _playerInput;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            _playerInput.enabled = false;
            _reachGoalCanvasManager.OpenCanvas();
            _sceneGameManager.ReachGoal();
        }
    }
}
