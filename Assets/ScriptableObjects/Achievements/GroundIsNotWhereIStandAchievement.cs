using UnityEngine;
[CreateAssetMenu(fileName = "GroundIsNotWhereIStandAchievement", menuName = "Achievements/GroundIsNotWhereIStandAchievement")]
public class GroundIsNotWhereIStandAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.GroundIsNotWhereIStand);
    }
}