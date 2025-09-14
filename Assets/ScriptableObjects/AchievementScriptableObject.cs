using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Achievement", menuName = "ScriptableObjectAssets/Achievement", order = 2)]
public class AchievementScriptableObject : ScriptableObject
{
    public bool FailedTheQC = false;
    public bool AProperGame = false;
    public bool NotEnoughMoneyToHireArtist = false;
    public bool WhoNeedsPrecision = false;
    public bool SkippedPhysicsInHighSchool = false;
    public bool NotAGoodCameraman = false;
    public bool PotatoPC = false;
    public bool NoControl = false;
    public bool SpeedRunner = false;
    public bool GroundIsNotWhereIStand = false;
    public bool FastestManAlive = false;
    public bool BadGraphics = false;
    public bool DoesWhateverASpiderCan = false;
    public bool YoureNotSupposedToGoThere = false;
    public bool RageQuitter = false;
    public bool YouShouldNotMakeAGame = false;
}
