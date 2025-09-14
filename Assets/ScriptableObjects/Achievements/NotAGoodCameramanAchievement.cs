using UnityEngine;
[CreateAssetMenu(fileName = "NotAGoodCameramanAchievement", menuName = "Achievements/NotAGoodCameramanAchievement")]
public class NotAGoodCameramanAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.NotAGoodCameraman);
    }
}