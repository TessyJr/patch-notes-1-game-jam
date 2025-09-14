using UnityEngine;
[CreateAssetMenu(fileName = "GroundIsNotWhereIStandAchievement", menuName = "Achievements/GroundIsNotWhereIStandAchievement")]
public class GroundIsNotWhereIStandAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    public override void Unlock()
    {
        SetIsUnlocked(achievementSO.GroundIsNotWhereIStand);
    }
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.GroundIsNotWhereIStand);
    }
}