using UnityEngine;
[CreateAssetMenu(fileName = "FailedTheQCAchievement", menuName = "Achievements/FailedTheQCAchievement")]
public class FailedTheQCAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.FailedTheQC);
    }
}