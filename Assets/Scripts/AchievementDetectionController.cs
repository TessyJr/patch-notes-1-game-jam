using System.Collections.Generic;
using UnityEngine;

public class AchievementDetectionController : MonoBehaviour
{
    [SerializeField] private PlayerSettingScriptableObject _playerSettingSO;
    [SerializeField] private WorldSettingScriptableObject _worldSettingSO;
    [SerializeField] private AchievementScriptableObject _achivementSO;
    [SerializeField] private PopupManager _popupManager;
    [SerializeField] private List<Achievement> _achievements;
    [SerializeField] private CounterScriptableObject _counterSO;

    [Header("Ground Is Not Where I Stand Settings")]
    [SerializeField] private PlayerMovement _playerMovement;
    private float _airTime = 0f;
    private float _wallTime = 0f;

    void Start()
    {
        CheckFailedTheQC();

        CheckAProperGame();

        CheckRageQuitter();

        CheckYouShouldNotMakeAGame();
    }

    void Update()
    {
        CheckGroundIsNotWhereIStand();
        CheckFastestManAlive();
        CheckDoesWhateverASpiderCan();
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
            _popupManager.ShowPopup(_achievements.Find(a => a.name == "AProperGameAchievement").GetName, _achievements.Find(a => a.name == "AProperGameAchievement").GetIcon);
        }
    }

    public void CheckNotEnoughMoneyToHireArtist()
    {
        if (_achivementSO.NotEnoughMoneyToHireArtist) return;

        if (_worldSettingSO.MissingTexture == true && _playerSettingSO.WrongAnimation)
        {
            _achivementSO.NotEnoughMoneyToHireArtist = true;
            _popupManager.ShowPopup(_achievements.Find(a => a.name == "NotEnoughMoneyToHireArtistAchievement").GetName, _achievements.Find(a => a.name == "NotEnoughMoneyToHireArtistAchievement").GetIcon);
        }
    }

    public void CheckWhoNeedsPrecision()
    {
        if (_achivementSO.WhoNeedsPrecision) return;

        if (_worldSettingSO.WrongOffset && _playerSettingSO.ShiftedHitbox)
        {
            _achivementSO.WhoNeedsPrecision = true;
            _popupManager.ShowPopup(_achievements.Find(a => a.name == "WhoNeedsPrecisionAchievement").GetName, _achievements.Find(a => a.name == "WhoNeedsPrecisionAchievement").GetIcon);
        }
    }

    public void CheckSkippedPhysicsInHighSchool()
    {
        if (_achivementSO.SkippedPhysicsInHighSchool) return;

        if (_worldSettingSO.PhysicsGoneWild && _worldSettingSO.GravityFlip && _playerSettingSO.WhatIsGround)
        {
            _achivementSO.SkippedPhysicsInHighSchool = true;
            _popupManager.ShowPopup(_achievements.Find(a => a.name == "SkippedPhysicsInHighSchoolAchievement").GetName, _achievements.Find(a => a.name == "SkippedPhysicsInHighSchoolAchievement").GetIcon);
        }
    }

    public void CheckNotAGoodCameraMan()
    {
        if (_achivementSO.NotAGoodCameraman) return;

        if (_worldSettingSO.UnsteadyHands && _worldSettingSO.LightingIssue)
        {
            _achivementSO.NotAGoodCameraman = true;
            _popupManager.ShowPopup(_achievements.Find(a => a.name == "NotAGoodCameramanAchievement").GetName, _achievements.Find(a => a.name == "NotAGoodCameramanAchievement").GetIcon);
        }
    }

    public void CheckPotatoPC()
    {
        if (_achivementSO.PotatoPC) return;

        if (_worldSettingSO.FPSDrop && _playerSettingSO.InputLag)
        {
            _achivementSO.PotatoPC = true;
            _popupManager.ShowPopup(_achievements.Find(a => a.name == "PotatoPCAchievement").GetName, _achievements.Find(a => a.name == "PotatoPCAchievement").GetIcon);
        }
    }

    public void CheckNoControl()
    {
        if (_achivementSO.NoControl) return;

        if (_playerSettingSO.BrokenControl)
        {
            _achivementSO.NoControl = true;
            _popupManager.ShowPopup(_achievements.Find(a => a.name == "NoControlAchievement").GetName, _achievements.Find(a => a.name == "NoControlAchievement").GetIcon);
        }
    }

    public void CheckSpeedrunner()
    {
        if (_achivementSO.SpeedRunner) return;

        if (Time.time <= 5.5f)
        {
            _achivementSO.SpeedRunner = true;
            _popupManager.ShowPopup(_achievements.Find(a => a.name == "SpeedrunnerAchievement").GetName, _achievements.Find(a => a.name == "SpeedrunnerAchievement").GetIcon);
        }
    }

    public void CheckGroundIsNotWhereIStand()
    {
        if (_achivementSO.GroundIsNotWhereIStand) return;

        if (!_playerMovement) return;

        if (_playerMovement.IsGrounded)
        {
            _airTime = 0f;
            return;
        }

        _airTime += Time.deltaTime;

        if (_airTime >= 3f)
        {
            _achivementSO.GroundIsNotWhereIStand = true;
            _popupManager.ShowPopup(_achievements.Find(a => a.name == "GroundIsNotWhereIStandAchievement").GetName, _achievements.Find(a => a.name == "GroundIsNotWhereIStandAchievement").GetIcon);
        }
    }

    public void CheckFastestManAlive()
    {
        if (_achivementSO.FastestManAlive) return;

        if (!_playerMovement) return;

        if (_playerMovement.GetMovementSpeed() >= 100f)
        {
            _achivementSO.FastestManAlive = true;
            _popupManager.ShowPopup(_achievements.Find(a => a.name == "FastestManAliveAchievement").GetName, _achievements.Find(a => a.name == "FastestManAliveAchievement").GetIcon);
        }
    }

    public void CheckBadGraphics(float renderValue)
    {
        if (_achivementSO.BadGraphics) return;

        if (renderValue <= 0.1f)
        {
            _achivementSO.BadGraphics = true;
            _popupManager.ShowPopup(_achievements.Find(a => a.name == "BadGraphicsAchievement").GetName, _achievements.Find(a => a.name == "BadGraphicsAchievement").GetIcon);
        }
    }

    public void CheckDoesWhateverASpiderCan()
    {
        if (_achivementSO.DoesWhateverASpiderCan) return;

        if (!_playerMovement) return;

        if (_playerMovement.IsGrounded || !_playerMovement.IsStickToWall)
        {
            _wallTime = 0f;
            return;
        }

        _wallTime += Time.deltaTime;

        if (_wallTime >= 3f)
        {
            _achivementSO.DoesWhateverASpiderCan = true;
            _popupManager.ShowPopup(_achievements.Find(a => a.name == "DoesWhateverASpiderCanAchievement").GetName, _achievements.Find(a => a.name == "DoesWhateverASpiderCanAchievement").GetIcon);
        }
    }

    public void CheckYoureNotSupposedToGoThere()
    {
        if (_achivementSO.YoureNotSupposedToGoThere) return;

        _achivementSO.YoureNotSupposedToGoThere = true;
        _popupManager.ShowPopup(_achievements.Find(a => a.name == "YoureNotSupposedToGoThereAchievement").GetName, _achievements.Find(a => a.name == "YoureNotSupposedToGoThereAchievement").GetIcon);
    }

    public void CheckRageQuitter()
    {
        if (_achivementSO.RageQuitter) return;

        if (_counterSO.DeathCounter >= 1 && _counterSO.QuitThrooughPause == true)
        {
            _achivementSO.RageQuitter = true;
            _popupManager.ShowPopup(_achievements.Find(a => a.name == "RageQuitterAchievement").GetName, _achievements.Find(a => a.name == "RageQuitterAchievement").GetIcon);
        }
    }

    public void CheckYouShouldNotMakeAGame()
    {
        if (_achivementSO.YouShouldNotMakeAGame) return;

        if (_achivementSO.AllUnlocked)
        {
            _achivementSO.YouShouldNotMakeAGame = true;
            _popupManager.ShowPopup(_achievements.Find(a => a.name == "YouShouldNotMakeAGameAchievement").GetName, _achievements.Find(a => a.name == "YouShouldNotMakeAGameAchievement").GetIcon);
        }
    }
}
