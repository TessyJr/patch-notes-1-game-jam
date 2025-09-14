using UnityEngine;
[CreateAssetMenu(fileName = "SkippedPhysicsInHighSchoolAchievement", menuName = "Achievements/SkippedPhysicsInHighSchoolAchievement")]
public class SkippedPhysicsInHighSchoolAchievement : Achievement
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    public override void Unlock()
    {
        SetIsUnlocked(achievementSO.SkippedPhysicsInHighSchool);
    }
}