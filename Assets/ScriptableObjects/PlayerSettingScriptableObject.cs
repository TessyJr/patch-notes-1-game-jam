using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSetting", menuName = "PlayerSetting", order = 1)]

public class PlayerSettingScriptableObject : ScriptableObject
{
    public bool WrongAnimation = false;
    public bool SpeedDemon = false;
    public bool WhatIsGround = false;
    public bool FPSDrop = false;
    public bool ShiftedHitbox = false;
    public bool HowToMove = false;
    public bool GlitchyTexture = false;
    public bool InputLag = false;

    public void Reset()
    {
        WrongAnimation = false;
        SpeedDemon = false;
        WhatIsGround = false;
        FPSDrop = false;
        ShiftedHitbox = false;
        HowToMove = false;
        GlitchyTexture = false;
        InputLag = false;
    }
}

