using UnityEngine;
[CreateAssetMenu(fileName = "SpeedrunnerAchievement", menuName = "Achievements/SpeedrunnerAchievement")]
public class SpeedrunnerAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    public override void Unlock()
    {
        SetIsUnlocked(achievementSO.SpeedRunner);
    }
}