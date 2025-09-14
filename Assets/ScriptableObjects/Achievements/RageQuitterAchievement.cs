using UnityEngine;
[CreateAssetMenu(fileName = "RageQuitterAchievement", menuName = "Achievements/RageQuitterAchievement")]
public class RageQuitterAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.RageQuitter);
    }
}