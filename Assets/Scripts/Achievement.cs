using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    [SerializeField] private string achievementName;
    [SerializeField] private string description;
    [SerializeField] private bool isUnlocked = false;
    [SerializeField] private Sprite icon;
    [SerializeField] private Image iconImage;
    [SerializeField] private PopupManager popupManager;

    void Start()
    {
        isUnlocked = PlayerPrefs.GetInt(achievementName, 0) == 1;
        iconImage.sprite = icon;
        iconImage.color = isUnlocked ? Color.white : Color.black;
    }

    public void ToggleLock()
    {
        if (!isUnlocked)
        {
            popupManager.ShowPopup(achievementName, icon);
            isUnlocked = true;
            PlayerPrefs.SetInt(achievementName, 1);
            Debug.Log($"Achievement Unlocked: {achievementName} - {description}");
        }
        else
        {
            isUnlocked = false;
            PlayerPrefs.SetInt(achievementName, 0);
            Debug.Log($"Achievement Locked: {achievementName}");
        }
    }

    public bool GetIsUnlocked => isUnlocked;
    public string GetName => achievementName;
    public string GetDescription => description;
    public Sprite GetIcon => icon;
    public void SetIconImageColor(Color color) => iconImage.color = color;
}
