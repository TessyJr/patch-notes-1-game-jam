using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementDetectionController : MonoBehaviour
{
    [SerializeField] private PlayerSettingScriptableObject _playerSettingSO;
    [SerializeField] private WorldSettingScriptableObject _worldSettingSO;
    [SerializeField] private AchievementScriptableObject _achivementSO;

    void Start()
    {
        CheckFailedTheQC();

        CheckAProperGame();
    }

    private void CheckFailedTheQC()
    {
        if (_achivementSO.FailedTheQC) return;

        if (_playerSettingSO.HasAny || _worldSettingSO.HasAny)
        {
            _achivementSO.FailedTheQC = true;
        }
    }

    private void CheckAProperGame()
    {
        if (_achivementSO.AProperGame) return;

        if (!_playerSettingSO.HasAny && !_playerSettingSO.HasAny)
        {
            _achivementSO.AProperGame = true;
        }
    }

    public void CheckNotEnoughMoneyToHireArtist()
    {
        if (_achivementSO.NotEnoughMoneyToHireArtist) return;

        if (_worldSettingSO.MissingTexture == true && _playerSettingSO.WrongAnimation)
        {
            _achivementSO.NotEnoughMoneyToHireArtist = true;
        }
    }

    public void CheckWhoNeedsPrecision()
    {
        if (_achivementSO.WhoNeedsPrecision) return;

        if (_worldSettingSO.WrongOffset && _playerSettingSO.ShiftedHitbox)
        {
            _achivementSO.WhoNeedsPrecision = true;
        }
    }

    public void CheckSkippedPhysicsInHighSchool()
    {
        if (_achivementSO.SkippedPhysicsInHighSchool) return;

        if (_worldSettingSO.PhysicsGoneWild && _worldSettingSO.GravityFlip && _playerSettingSO.WhatIsGround)
        {
            _achivementSO.SkippedPhysicsInHighSchool = true;
        }
    }

    public void CheckNotAGoodCameraMan()
    {
        if (_achivementSO.NotAGoodCameraman) return;

        if (_worldSettingSO.UnsteadyHands && _worldSettingSO.LightingIssue)
        {
            _achivementSO.NotAGoodCameraman = true;
        }
    }

    public void CheckPotatoPC()
    {
        if (_achivementSO.PotatoPC) return;

        if (_worldSettingSO.FPSDrop && _playerSettingSO.InputLag)
        {
            _achivementSO.PotatoPC = true;
        }
    }

    public void CheckNoControl()
    {
        if (_achivementSO.NoControl) return;

        if (_playerSettingSO.BrokenControl)
        {
            _achivementSO.NoControl = true;
        }
    }

    public void CheckSpeedRunner()
    {
        if (_achivementSO.SpeedRunner) return;

        if (Time.time <= 5.5f)
        {
            _achivementSO.SpeedRunner = true;
        }
    }

    public void CheckGroundIsNotWhereIStand()
    {

    }

    public void CheckFastestManAlive()
    {

    }

    public void CheckBadGraphics()
    {

    }

    public void CheckDoesWhateverASpiderCan()
    {

    }

    public void CheckYoureNotSupposedToGoThere()
    {
        if (_achivementSO.YoureNotSupposedToGoThere) return;

        _achivementSO.YoureNotSupposedToGoThere = true;
    }

    public void CheckRageQuitter()
    {

    }

    public void CheckYouShouldNotMakeAGame()
    {
        if (_achivementSO.YouShouldNotMakeAGame) return;

        if (_achivementSO.AllUnlocked)
        {
            _achivementSO.YouShouldNotMakeAGame = true;
        }
    }
}
