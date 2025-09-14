using UnityEngine;
[CreateAssetMenu(fileName = "PotatoPCAchievement", menuName = "Achievements/PotatoPCAchievement")]
public class PotatoPCAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.PotatoPC);
    }
}