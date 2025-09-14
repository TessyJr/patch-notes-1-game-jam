using UnityEngine;
[CreateAssetMenu(fileName = "YouShouldNotMakeAGameAchievement", menuName = "Achievements/YouShouldNotMakeAGameAchievement")]
public class YouShouldNotMakeAGameAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.YouShouldNotMakeAGame);
    }
}