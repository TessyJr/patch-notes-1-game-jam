using UnityEngine;
[CreateAssetMenu(fileName = "RageQuitterAchievement", menuName = "Achievements/RageQuitterAchievement")]
public class RageQuitterAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    public override void Unlock()
    {
        SetIsUnlocked(achievementSO.RageQuitter);
    }
}