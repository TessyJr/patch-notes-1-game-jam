using UnityEngine;
[CreateAssetMenu(fileName = "FastestManAliveAchievement", menuName = "Achievements/FastestManAliveAchievement")]
public class FastestManAliveAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    public override void Unlock()
    {
        SetIsUnlocked(achievementSO.FastestManAlive);
    }
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.FastestManAlive);
    }
}