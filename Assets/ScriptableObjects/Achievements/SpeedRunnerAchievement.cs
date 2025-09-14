using UnityEngine;
[CreateAssetMenu(fileName = "SpeedrunnerAchievement", menuName = "Achievements/SpeedrunnerAchievement")]
public class SpeedrunnerAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.SpeedRunner);
    }
}