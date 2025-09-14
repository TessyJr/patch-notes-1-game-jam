using UnityEngine;
[CreateAssetMenu(fileName = "DoesWhateverASpiderCanAchievement", menuName = "Achievements/DoesWhateverASpiderCanAchievement")]
public class DoesWhateverASpiderCanAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    public override void Unlock()
    {
        SetIsUnlocked(achievementSO.DoesWhateverASpiderCan);
    }
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.DoesWhateverASpiderCan);
    }
}