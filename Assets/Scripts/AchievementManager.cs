using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private AchievementItem _activeAchievement;
    [SerializeField] private TextMeshProUGUI achievementText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI clueText;
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
        OnAchievementChange(_activeAchievement);
    }

    private void OnAchievementChange(AchievementItem achievement)
    {
        Achievement achievementSO = achievement.GetAchievementSO;
        achievement.SetIconImageColor(achievementSO.GetIsUnlocked ? Color.white : Color.black);
        achievementText.text = achievementSO.GetName;
        clueText.text = achievementSO.GetClueText;
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