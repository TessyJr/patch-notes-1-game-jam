using UnityEngine;
[CreateAssetMenu(fileName = "YoureNotSupposedToGoThereAchievement", menuName = "Achievements/YoureNotSupposedToGoThereAchievement")]
public class YoureNotSupposedToGoThereAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.YoureNotSupposedToGoThere);
    }
}