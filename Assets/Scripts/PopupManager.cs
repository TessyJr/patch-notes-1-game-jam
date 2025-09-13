using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _achievementName;
    [SerializeField] private Image _iconImage;
    [SerializeField] Animator _animator;
    public void ShowPopup(string name, Sprite icon)
    {
        _achievementName.text = name;
        _iconImage.sprite = icon;
        _animator.SetTrigger("Pop");
    }
}
