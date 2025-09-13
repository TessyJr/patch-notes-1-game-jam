using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private List<Achievement> _achievements = new List<Achievement>();
    [SerializeField] private Achievement _activeAchievement;
    [SerializeField] private TextMeshProUGUI achievementText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image iconImage;

    public Achievement ActiveAchievement
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

    private void OnAchievementChange(Achievement achievement)
    {
        achievement.SetIconImageColor(achievement.GetIsUnlocked ? Color.white : Color.black);
        achievementText.text = achievement.GetName;
        iconImage.sprite = achievement.GetIcon;
        iconImage.color = achievement.GetIsUnlocked ? Color.white : Color.black;
        if (achievement.GetIsUnlocked)
        {
            descriptionText.text = achievement.GetDescription;
        }
        else
        {
            descriptionText.text = "(????)";
        }
    }

    public void ToggleActiveAchievementLock()
    {
        if (_activeAchievement != null)
        {
            _activeAchievement.ToggleLock();
            OnAchievementChange(_activeAchievement);
        }
    }

    private string GetRandomLockedText()
    {
        var lockedTexts = new List<string>
        {
            "(????)",
            "Achievement Locked",
            "I think you should find out yourself",
            "lorem ipsum dolor sit amet",
            "_activeAchievement.GetDescription"
        };
        int index = Random.Range(0, lockedTexts.Count);
        return lockedTexts[index];
    }
}