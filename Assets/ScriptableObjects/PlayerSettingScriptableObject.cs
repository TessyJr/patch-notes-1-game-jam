using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSetting", menuName = "ScriptableObjectAssets/PlayerSetting", order = 1)]
public class PlayerSettingScriptableObject : ScriptableObject
{
    public bool WrongAnimation = false;
    public bool WhatIsGround = false;
    public bool ShiftedHitbox = false;
    public bool SpeedDemon = false;
    public bool BrokenControl = false;
    public bool InputLag = false;

    public void Reset()
    {
        WrongAnimation = false;
        SpeedDemon = false;
        WhatIsGround = false;
        ShiftedHitbox = false;
        BrokenControl = false;
        InputLag = false;
    }
}

