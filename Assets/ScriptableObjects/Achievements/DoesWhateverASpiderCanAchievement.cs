using UnityEngine;
[CreateAssetMenu(fileName = "DoesWhateverASpiderCanAchievement", menuName = "Achievements/DoesWhateverASpiderCanAchievement")]
public class DoesWhateverASpiderCanAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.DoesWhateverASpiderCan);
    }
}