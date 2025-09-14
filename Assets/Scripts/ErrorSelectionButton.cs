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
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
    }
    public void ToggleSelection()
    {
        if (isWorldError && menuManager.GetSelectedWorldErrorCount() >= 3 && !isSelected)
            return;
        if (!isWorldError && menuManager.GetSelectedPlayerErrorCount() >= 3 && !isSelected)
            return;
        isSelected = !isSelected;
        errorText.color = isSelected ? Color.white : Color.black;
        var buttonColorBlock = button.colors;
        buttonColorBlock.normalColor = isSelected ? Color.black : Color.white;
        buttonColorBlock.selectedColor = isSelected ? new Color32(0x96, 0xA4, 0x30, 0xFF) : new Color32(0xEA, 0xFF, 0x53, 0xFF);
        button.colors = buttonColorBlock;

        backgroundImage.color = isSelected ? new Color32(0x96, 0xA4, 0x30, 0xFF) : Color.white;
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
