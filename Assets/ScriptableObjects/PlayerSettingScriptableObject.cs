using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "PlayerSetting", menuName = "ScriptableObjectAssets/PlayerSetting", order = 1)]
public class PlayerSettingScriptableObject : ScriptableObject
{
    public bool WrongAnimation;
    public bool WhatIsGround;
    public bool ShiftedHitbox;
    public bool SpeedDemon;
    public bool BrokenControl;
    public bool InputLag;

    public void Reset()
    {
        WrongAnimation = false;
        SpeedDemon = false;
        WhatIsGround = false;
        ShiftedHitbox = false;
        BrokenControl = false;
        InputLag = false;
    }

    public bool HasAny =>
    new bool[] {
        WrongAnimation,
        WhatIsGround,
        ShiftedHitbox,
        SpeedDemon,
        BrokenControl,
        InputLag
    }.Any(b => b);
}

