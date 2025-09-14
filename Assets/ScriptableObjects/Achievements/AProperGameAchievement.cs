using UnityEngine;
[CreateAssetMenu(fileName = "AProperGameAchievement", menuName = "Achievements/AProperGameAchievement")]
public class AProperGameAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.AProperGame);
    }
}