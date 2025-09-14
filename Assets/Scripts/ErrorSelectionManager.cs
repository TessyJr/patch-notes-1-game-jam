using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ErrorSelectionManager : MonoBehaviour
{
    [SerializeField] private ErrorSelectionButton _activeError;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image iconImage;

    public ErrorSelectionButton ActiveError
    {
        get => _activeError;
        set
        {
            if (_activeError != value)
            {
                _activeError = value;
                OnErrorChange(_activeError);
            }
        }
    }

    void Start()
    {
        OnErrorChange(_activeError);
    }

    private void OnErrorChange(ErrorSelectionButton error)
    {
        nameText.text = error.ToString();
        descriptionText.text = error.GetDescription();
        iconImage.sprite = error.GetIcon();
    }
}