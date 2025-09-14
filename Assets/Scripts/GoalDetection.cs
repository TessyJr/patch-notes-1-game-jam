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
            AudioManager.Instance.PlaySFX(AudioManager.Instance.WinSFX);

            _playerInput.actions.Disable();

            _reachGoalCanvasManager.OpenCanvas();
            _sceneGameManager.ReachGoal();

            collision.transform.tag = "Untagged";
        }
    }
}
