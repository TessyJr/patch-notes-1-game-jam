using UnityEngine;
[CreateAssetMenu(fileName = "NotAGoodCameramanAchievement", menuName = "Achievements/NotAGoodCameramanAchievement")]
public class NotAGoodCameramanAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    public override void Unlock()
    {
        SetIsUnlocked(achievementSO.NotAGoodCameraman);
    }
}