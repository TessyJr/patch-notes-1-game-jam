using UnityEngine;
[CreateAssetMenu(fileName = "SpeedRunnerAchievement", menuName = "Achievements/SpeedRunnerAchievement")]
public class SpeedRunnerAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.SpeedRunner);
    }
}