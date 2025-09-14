using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private List<WorldError> _selectedWorldErrors;
    [SerializeField] private List<PlayerError> _selectedPlayerErrors;
    [SerializeField] private WorldSettingScriptableObject _worldSettingSO;
    [SerializeField] private PlayerSettingScriptableObject _playerSettingSO;
    void Awake()
    {
        _playerSettingSO.Reset();
        _worldSettingSO.Reset();
    }

    public void ToggleWorldError(WorldError error, bool value)
    {
        if (value)
        {
            _selectedWorldErrors.Add(error);
        }
        else
        {
            _selectedWorldErrors.Remove(error);
        }
        switch (error)
        {
            case WorldError.MissingTexture:
                _worldSettingSO.MissingTexture = value;
                break;
            case WorldError.PhysicsGoneWild:
                _worldSettingSO.PhysicsGoneWild = value;
                break;
            case WorldError.UnsteadyHands:
                _worldSettingSO.UnsteadyHands = value;
                break;
            case WorldError.InconsistentFriction:
                _worldSettingSO.InconsistentFriction = value;
                break;
            case WorldError.FpsDrop:
                _worldSettingSO.FPSDrop = value;
                break;
            case WorldError.WrongOffset:
                _worldSettingSO.WrongOffset = value;
                break;
            case WorldError.GravityFlip:
                _worldSettingSO.GravityFlip = value;
                break;
            case WorldError.LightingIssue:
                _worldSettingSO.LightingIssue = value;
                break;
            case WorldError.QualityChange:
                _worldSettingSO.QualityChange = value;
                break;
            case WorldError.GlitchyWorld:
                _worldSettingSO.GlitchyWorld = value;
                break;
            default:
                break;
        }
    }
    public void TogglePlayerError(PlayerError error, bool value)
    {
        if (value)
        {
            _selectedPlayerErrors.Add(error);
        }
        else
        {
            _selectedPlayerErrors.Remove(error);
        }
        switch (error)
        {
            case PlayerError.WrongAnimation:
                _playerSettingSO.WrongAnimation = value;
                break;
            case PlayerError.SpeedDemon:
                _playerSettingSO.SpeedDemon = value;
                break;
            case PlayerError.WhatIsGround:
                _playerSettingSO.WhatIsGround = value;
                break;
            case PlayerError.ShiftedHitbox:
                _playerSettingSO.ShiftedHitbox = value;
                break;
            case PlayerError.BrokenControl:
                _playerSettingSO.BrokenControl = value;
                break;
            case PlayerError.InputLag:
                _playerSettingSO.InputLag = value;
                break;
            default:
                break;
        }
    }
    public int GetSelectedWorldErrorCount()
    {
        return _selectedWorldErrors.Count;
    }
    public int GetSelectedPlayerErrorCount()
    {
        return _selectedPlayerErrors.Count;
    }
}
