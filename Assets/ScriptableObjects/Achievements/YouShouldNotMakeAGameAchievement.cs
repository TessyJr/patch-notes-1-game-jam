using UnityEngine;
[CreateAssetMenu(fileName = "YouShouldNotMakeAGameAchievement", menuName = "Achievements/YouShouldNotMakeAGameAchievement")]
public class YouShouldNotMakeAGameAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    public override void Unlock()
    {
        SetIsUnlocked(achievementSO.YouShouldNotMakeAGame);
    }
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.YouShouldNotMakeAGame);
    }
}