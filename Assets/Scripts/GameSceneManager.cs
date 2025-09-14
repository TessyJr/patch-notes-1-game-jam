using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneGameManager : MonoBehaviour
{
    [SerializeField] private AchievementDetectionController _achievementDetectionController;

    void Awake()
    {
        Time.timeScale = 1;
    }

    public void ReachGoal()
    {
        _achievementDetectionController.CheckNotEnoughMoneyToHireArtist();
        _achievementDetectionController.CheckWhoNeedsPrecision();
        _achievementDetectionController.CheckSkippedPhysicsInHighSchool();
        _achievementDetectionController.CheckNotAGoodCameraMan();
        _achievementDetectionController.CheckPotatoPC();
        _achievementDetectionController.CheckNoControl();
        _achievementDetectionController.CheckSpeedrunner();
        _achievementDetectionController.CheckAProperGame();
        _achievementDetectionController.CheckFailedTheQC();
    }

    public void Restart(float delay = 0f)
    {
        StartCoroutine(RestartAfterDelay(delay));
    }

    private IEnumerator RestartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void Exit()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
