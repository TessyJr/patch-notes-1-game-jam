using UnityEngine;
[CreateAssetMenu(fileName = "FastestManAliveAchievement", menuName = "Achievements/FastestManAliveAchievement")]
public class FastestManAliveAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.FastestManAlive);
    }
}