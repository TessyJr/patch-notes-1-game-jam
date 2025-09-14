using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "WorldSetting", menuName = "ScriptableObjectAssets/WorldSetting", order = 0)]
public class WorldSettingScriptableObject : ScriptableObject
{
    public bool MissingTexture;
    public bool PhysicsGoneWild;
    public bool UnsteadyHands;
    public bool InconsistentFriction;
    public bool FPSDrop;
    public bool WrongOffset;
    public bool GravityFlip;
    public bool LightingIssue;
    public bool QualityChange;
    public bool GlitchyWorld;

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

    public bool HasAny =>
    new bool[] {
        MissingTexture,
        PhysicsGoneWild,
        UnsteadyHands,
        InconsistentFriction,
        FPSDrop,
        WrongOffset,
        GravityFlip,
        LightingIssue,
        QualityChange,
        GlitchyWorld
    }.Any(b => b);
}

