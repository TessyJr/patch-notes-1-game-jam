using UnityEngine;
[CreateAssetMenu(fileName = "PotatoPCAchievement", menuName = "Achievements/PotatoPCAchievement")]
public class PotatoPCAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    public override void Unlock()
    {
        SetIsUnlocked(achievementSO.PotatoPC);
    }
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.PotatoPC);
    }
}