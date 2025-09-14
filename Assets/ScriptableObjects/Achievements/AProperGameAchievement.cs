using UnityEngine;
[CreateAssetMenu(fileName = "AProperGameAchievement", menuName = "Achievements/AProperGameAchievement")]
public class AProperGameAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    public override void Unlock()
    {
        SetIsUnlocked(achievementSO.AProperGame);
    }
}