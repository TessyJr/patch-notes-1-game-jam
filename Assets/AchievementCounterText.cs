using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementCounterText : MonoBehaviour
{
    [SerializeField] private AchievementScriptableObject achievementSO;
    [SerializeField] private TMPro.TextMeshProUGUI achievementCounterText;
    void Start()
    {
        achievementCounterText.text = $"Achievement Unlocked: {achievementSO.AchievementsUnlockedCount}/16";
    }
}
