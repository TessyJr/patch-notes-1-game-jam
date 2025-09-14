using UnityEngine;
[CreateAssetMenu(fileName = "WhoNeedsPrecisionAchievement", menuName = "Achievements/WhoNeedsPrecisionAchievement")]
public class WhoNeedsPrecisionAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    public override void Unlock()
    {
        SetIsUnlocked(achievementSO.WhoNeedsPrecision);
    }
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.WhoNeedsPrecision);
    }
}