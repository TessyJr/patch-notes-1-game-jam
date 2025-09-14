using UnityEngine;
using UnityEngine.UI;

public abstract class Achievement : ScriptableObject
{
    [SerializeField] private string achievementName;
    [TextArea][SerializeField] private string description;
    [TextArea][SerializeField] private string clueText;
    [SerializeField] private bool isUnlocked;
    [SerializeField] private Sprite icon;


    public bool GetIsUnlocked => isUnlocked;
    public void SetIsUnlocked(bool value) => isUnlocked = value;
    public string GetName => achievementName;
    public string GetDescription => description;
    public Sprite GetIcon => icon;
    public string GetClueText => clueText;

}
