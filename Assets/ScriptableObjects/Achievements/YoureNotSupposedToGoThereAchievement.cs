using UnityEngine;
[CreateAssetMenu(fileName = "YoureNotSupposedToGoThereAchievement", menuName = "Achievements/YoureNotSupposedToGoThereAchievement")]
public class YoureNotSupposedToGoThereAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    public override void Unlock()
    {
        SetIsUnlocked(achievementSO.YoureNotSupposedToGoThere);
    }
}