using UnityEngine;

[CreateAssetMenu(fileName = "Achievement", menuName = "ScriptableObjectAssets/Achievement", order = 2)]
public class AchievementScriptableObject : ScriptableObject
{
    public bool FailedTheQC;
    public bool AProperGame;
    public bool NotEnoughMoneyToHireArtist;
    public bool WhoNeedsPrecision;
    public bool SkippedPhysicsInHighSchool;
    public bool NotAGoodCameraman;
    public bool PotatoPC;
    public bool NoControl;
    public bool SpeedRunner;
    public bool GroundIsNotWhereIStand;
    public bool FastestManAlive;
    public bool BadGraphics;
    public bool DoesWhateverASpiderCan;
    public bool YoureNotSupposedToGoThere;
    public bool RageQuitter;
    public bool YouShouldNotMakeAGame;

    public void Initialize()
    {
        FailedTheQC = false;
        AProperGame = false;
        NotEnoughMoneyToHireArtist = false;
        WhoNeedsPrecision = false;
        SkippedPhysicsInHighSchool = false;
        NotAGoodCameraman = false;
        PotatoPC = false;
        NoControl = false;
        SpeedRunner = false;
        GroundIsNotWhereIStand = false;
        FastestManAlive = false;
        BadGraphics = false;
        DoesWhateverASpiderCan = false;
        YoureNotSupposedToGoThere = false;
        RageQuitter = false;
        YouShouldNotMakeAGame = false;
    }

    public bool AllUnlocked =>
    FailedTheQC &&
    AProperGame &&
    NotEnoughMoneyToHireArtist &&
    WhoNeedsPrecision &&
    SkippedPhysicsInHighSchool &&
    NotAGoodCameraman &&
    PotatoPC &&
    NoControl &&
    SpeedRunner &&
    GroundIsNotWhereIStand &&
    FastestManAlive &&
    BadGraphics &&
    DoesWhateverASpiderCan &&
    YoureNotSupposedToGoThere &&
    RageQuitter;

    public int AchievementsUnlockedCount
    {
        get
        {
            int count = 0;
            if (FailedTheQC) count++;
            if (AProperGame) count++;
            if (NotEnoughMoneyToHireArtist) count++;
            if (WhoNeedsPrecision) count++;
            if (SkippedPhysicsInHighSchool) count++;
            if (NotAGoodCameraman) count++;
            if (PotatoPC) count++;
            if (NoControl) count++;
            if (SpeedRunner) count++;
            if (GroundIsNotWhereIStand) count++;
            if (FastestManAlive) count++;
            if (BadGraphics) count++;
            if (DoesWhateverASpiderCan) count++;
            if (YoureNotSupposedToGoThere) count++;
            if (RageQuitter) count++;
            if (YouShouldNotMakeAGame) count++;
            return count;
        }
    }
}
