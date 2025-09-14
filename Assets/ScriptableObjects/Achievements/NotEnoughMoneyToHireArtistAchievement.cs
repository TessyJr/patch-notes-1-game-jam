using UnityEngine;
[CreateAssetMenu(fileName = "NotEnoughMoneyToHireArtistAchievement", menuName = "Achievements/NotEnoughMoneyToHireArtistAchievement")]
public class NotEnoughMoneyToHireArtistAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.NotEnoughMoneyToHireArtist);
    }
}