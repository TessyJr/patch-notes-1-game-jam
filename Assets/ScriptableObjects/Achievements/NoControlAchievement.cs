using UnityEngine;
[CreateAssetMenu(fileName = "NoControlAchievement", menuName = "Achievements/NoControlAchievement")]
public class NoControlAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.NoControl);
    }
}