using UnityEngine;
using UnityEngine.UI;

public class AchievementItem : MonoBehaviour
{
    [SerializeField] private Achievement achievementSO;
    [SerializeField] private Image iconImage;

    void Start()
    {
        iconImage.sprite = achievementSO.GetIcon;
        iconImage.color = achievementSO.GetIsUnlocked ? Color.white : new Color(0.25f, 0.25f, 0.25f);
    }
    public Achievement GetAchievementSO => achievementSO;
    public void SetIconImageColor(Color color) => iconImage.color = color;
}