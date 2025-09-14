using UnityEngine;
[CreateAssetMenu(fileName = "BadGraphicsAchievement", menuName = "Achievements/BadGraphicsAchievement")]
public class BadGraphicsAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    public override void Unlock()
    {
        SetIsUnlocked(achievementSO.BadGraphics);
    }
}