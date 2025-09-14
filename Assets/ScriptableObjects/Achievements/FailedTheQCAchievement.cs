using UnityEngine;
[CreateAssetMenu(fileName = "FailedTheQCAchievement", menuName = "Achievements/FailedTheQCAchievement")]
public class FailedTheQCAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    public override void Unlock()
    {
        SetIsUnlocked(achievementSO.FailedTheQC);
    }
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.FailedTheQC);
    }
}