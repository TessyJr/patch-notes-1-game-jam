using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupItem : MonoBehaviour
{
    [SerializeField] private AchievementItem achievementItem;
    [SerializeField] private TMPro.TextMeshProUGUI achievementText;
    [SerializeField] private TMPro.TextMeshProUGUI descriptionText;
    private Achievement achievementSO;
    void Start()
    {
        achievementSO = achievementItem.GetAchievementSO;
        achievementText.text = achievementSO.GetName;
        if (achievementSO.GetIsUnlocked)
        {
            descriptionText.text = achievementSO.GetDescription;
        }
        else
        {
            descriptionText.text = "(????)";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
