using UnityEngine;
[CreateAssetMenu(fileName = "NotEnoughMoneyToHireArtistAchievement", menuName = "Achievements/NotEnoughMoneyToHireArtistAchievement")]
public class NotEnoughMoneyToHireArtistAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    public override void Unlock()
    {
        SetIsUnlocked(achievementSO.NotEnoughMoneyToHireArtist);
    }
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.NotEnoughMoneyToHireArtist);
    }
}