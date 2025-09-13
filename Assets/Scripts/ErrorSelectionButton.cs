using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ErrorSelectionButton : MonoBehaviour
{
    [SerializeField] private bool isSelected = false;
    [SerializeField] private bool isWorldError = true;
    [SerializeField] private WorldError worldError;
    [SerializeField] private PlayerError playerError;
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private TextMeshProUGUI errorText;
    [SerializeField] private TextMeshProUGUI playerLimitText;
    [SerializeField] private TextMeshProUGUI worldLimitText;
    public void ToggleSelection()
    {
        if (isWorldError && menuManager.GetSelectedWorldErrorCount() >= 3 && !isSelected)
            return;
        if (!isWorldError && menuManager.GetSelectedPlayerErrorCount() >= 3 && !isSelected)
            return;
        isSelected = !isSelected;
        backgroundImage.color = isSelected ? Color.black : Color.white;
        errorText.color = isSelected ? Color.white : Color.black;
        if (isWorldError)
        {
            menuManager.ToggleWorldError(worldError, isSelected);
        }
        else
        {
            menuManager.TogglePlayerError(playerError, isSelected);
        }
        playerLimitText.text = $"Player Errors: {menuManager.GetSelectedPlayerErrorCount()}/3";
        worldLimitText.text = $"World Errors: {menuManager.GetSelectedWorldErrorCount()}/3";
    }
}
