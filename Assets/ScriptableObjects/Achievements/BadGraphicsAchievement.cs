using UnityEngine;
[CreateAssetMenu(fileName = "BadGraphicsAchievement", menuName = "Achievements/BadGraphicsAchievement")]
public class BadGraphicsAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.BadGraphics);
    }
}