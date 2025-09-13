using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "WorldSetting", menuName = "WorldSetting", order = 0)]

public class WorldSettingScriptableObject : ScriptableObject
{
    public bool MissingTexture = false;
    public bool PhysicsGoneWild = false;
    public bool UnsteadyHands = false;
    public bool InconsistentFriction = false;
    public bool WrongOffset = false;
    public bool GravityFlip = false;
    public bool LightingIssue = false;
    public bool WindmillPlatform = false;

    public void Reset()
    {
        MissingTexture = false;
        PhysicsGoneWild = false;
        UnsteadyHands = false;
        InconsistentFriction = false;
        WrongOffset = false;
        GravityFlip = false;
        LightingIssue = false;
        WindmillPlatform = false;
    }
}

