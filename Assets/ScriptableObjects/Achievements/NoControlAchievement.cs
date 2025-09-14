using UnityEngine;
[CreateAssetMenu(fileName = "NoControlAchievement", menuName = "Achievements/NoControlAchievement")]
public class NoControlAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    public override void Unlock()
    {
        SetIsUnlocked(achievementSO.NoControl);
    }
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.NoControl);
    }
}