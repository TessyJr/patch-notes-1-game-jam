using UnityEngine;
[CreateAssetMenu(fileName = "SkippedPhysicsInHighSchoolAchievement", menuName = "Achievements/SkippedPhysicsInHighSchoolAchievement")]
public class SkippedPhysicsInHighSchoolAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    void OnEnable()
    {
        SetIsUnlocked(achievementSO.SkippedPhysicsInHighSchool);
    }
}