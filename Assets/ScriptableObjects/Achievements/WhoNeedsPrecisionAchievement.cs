using UnityEngine;
[CreateAssetMenu(fileName = "WhoNeedsPrecisionAchievement", menuName = "Achievements/WhoNeedsPrecisionAchievement")]
public class WhoNeedsPrecisionAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.WhoNeedsPrecision);
    }
}