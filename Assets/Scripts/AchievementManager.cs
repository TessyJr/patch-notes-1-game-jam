using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private List<AchievementItem> _achievements = new List<AchievementItem>();
    [SerializeField] private AchievementItem _activeAchievement;
    [SerializeField] private TextMeshProUGUI achievementText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image iconImage;

    public AchievementItem ActiveAchievement
    {
        get => _activeAchievement;
        set
        {
            if (_activeAchievement != value)
            {
                _activeAchievement = value;
                OnAchievementChange(_activeAchievement);
            }
        }
    }

    void Start()
    {
        if (_achievements.Count > 0)
        {
            ActiveAchievement = _achievements[0];
            OnAchievementChange(_activeAchievement);
        }
    }

    private void OnAchievementChange(AchievementItem achievement)
    {
        Achievement achievementSO = achievement.GetAchievementSO;
        achievement.SetIconImageColor(achievementSO.GetIsUnlocked ? Color.white : Color.black);
        achievementText.text = achievementSO.GetName;
        iconImage.sprite = achievementSO.GetIcon;
        iconImage.color = achievementSO.GetIsUnlocked ? Color.white : Color.black;
        if (achievementSO.GetIsUnlocked)
        {
            descriptionText.text = achievementSO.GetDescription;
        }
        else
        {
            descriptionText.text = "(????)";
        }
    }
}