using UnityEngine;

[CreateAssetMenu(fileName = "WorldSetting", menuName = "ScriptableObjectAssets/WorldSetting", order = 0)]
public class WorldSettingScriptableObject : ScriptableObject
{
    public bool MissingTexture = false;
    public bool PhysicsGoneWild = false;
    public bool UnsteadyHands = false;
    public bool InconsistentFriction = false;
    public bool FPSDrop = false;
    public bool WrongOffset = false;
    public bool GravityFlip = false;
    public bool LightingIssue = false;
    public bool QualityChange = false;
    public bool GlitchyWorld = false;

    public void Reset()
    {
        MissingTexture = false;
        PhysicsGoneWild = false;
        UnsteadyHands = false;
        InconsistentFriction = false;
        FPSDrop = false;
        WrongOffset = false;
        GravityFlip = false;
        LightingIssue = false;
        QualityChange = false;
        GlitchyWorld = false;
    }
}

