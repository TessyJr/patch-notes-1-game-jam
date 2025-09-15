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
        CheckRageQuitter();

        CheckYouShouldNotMakeAGame();
    }

    void Update()
    {
        CheckGroundIsNotWhereIStand();
        CheckFastestManAlive();
        CheckDoesWhateverASpiderCan();
    }

    public void CheckFailedTheQC()
    {
        if (_achivementSO.FailedTheQC) return;

        if (_playerSettingSO.HasAny || _worldSettingSO.HasAny)
        {
            _achivementSO.FailedTheQC = true;
            Achievement achievement = _achievements.Find(a => a.name == "FailedTheQCAchievement");
            achievement.Unlock();
            _popupManager.ShowPopup(achievement.GetName, achievement.GetIcon);
        }
    }

    public void CheckAProperGame()
    {
        if (_achivementSO.AProperGame) return;

        if (!_worldSettingSO.HasAny && !_playerSettingSO.HasAny)
        {
            _achivementSO.AProperGame = true;
            Achievement achievement = _achievements.Find(a => a.name == "AProperGameAchievement");
            achievement.Unlock();
            _popupManager.ShowPopup(achievement.GetName, achievement.GetIcon);
        }
    }

    public void CheckNotEnoughMoneyToHireArtist()
    {
        if (_achivementSO.NotEnoughMoneyToHireArtist) return;

        if (_worldSettingSO.MissingTexture == true && _playerSettingSO.WrongAnimation)
        {
            _achivementSO.NotEnoughMoneyToHireArtist = true;
            Achievement achievement = _achievements.Find(a => a.name == "NotEnoughMoneyToHireArtistAchievement");
            achievement.Unlock();
            _popupManager.ShowPopup(achievement.GetName, achievement.GetIcon);        }
    }

    public void CheckWhoNeedsPrecision()
    {
        if (_achivementSO.WhoNeedsPrecision) return;

        if (_worldSettingSO.WrongOffset && _playerSettingSO.ShiftedHitbox)
        {
            _achivementSO.WhoNeedsPrecision = true;
            Achievement achievement = _achievements.Find(a => a.name == "WhoNeedsPrecisionAchievement");
            achievement.Unlock();
            _popupManager.ShowPopup(achievement.GetName, achievement.GetIcon);        }
    }

    public void CheckSkippedPhysicsInHighSchool()
    {
        if (_achivementSO.SkippedPhysicsInHighSchool) return;

        if (_worldSettingSO.PhysicsGoneWild && _worldSettingSO.GravityFlip && _playerSettingSO.WhatIsGround)
        {
            _achivementSO.SkippedPhysicsInHighSchool = true;
            Achievement achievement = _achievements.Find(a => a.name == "SkippedPhysicsInHighSchoolAchievement");
            achievement.Unlock();
            _popupManager.ShowPopup(achievement.GetName, achievement.GetIcon);        }
    }

    public void CheckNotAGoodCameraMan()
    {
        if (_achivementSO.NotAGoodCameraman) return;

        if (_worldSettingSO.UnsteadyHands && _worldSettingSO.LightingIssue)
        {
            _achivementSO.NotAGoodCameraman = true;
            Achievement achievement = _achievements.Find(a => a.name == "NotAGoodCameramanAchievement");
            achievement.Unlock();
            _popupManager.ShowPopup(achievement.GetName, achievement.GetIcon);        }
    }

    public void CheckPotatoPC()
    {
        if (_achivementSO.PotatoPC) return;

        if (_worldSettingSO.FPSDrop && _playerSettingSO.InputLag)
        {
            _achivementSO.PotatoPC = true;
            Achievement achievement = _achievements.Find(a => a.name == "PotatoPCAchievement");
            achievement.Unlock();
            _popupManager.ShowPopup(achievement.GetName, achievement.GetIcon);        }
    }

    public void CheckNoControl()
    {
        if (_achivementSO.NoControl) return;

        if (_playerSettingSO.BrokenControl)
        {
            _achivementSO.NoControl = true;
            Achievement achievement = _achievements.Find(a => a.name == "NoControlAchievement");
            achievement.Unlock();
            _popupManager.ShowPopup(achievement.GetName, achievement.GetIcon);        }
    }

    public void CheckSpeedrunner()
    {
        if (_achivementSO.SpeedRunner) return;

        if (Time.time <= 5.5f)
        {
            _achivementSO.SpeedRunner = true;
            Achievement achievement = _achievements.Find(a => a.name == "SpeedrunnerAchievement");
            achievement.Unlock();
            _popupManager.ShowPopup(achievement.GetName, achievement.GetIcon);        }
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
            Achievement achievement = _achievements.Find(a => a.name == "GroundIsNotWhereIStandAchievement");
            achievement.Unlock();
            _popupManager.ShowPopup(achievement.GetName, achievement.GetIcon);        }
    }

    public void CheckFastestManAlive()
    {
        if (_achivementSO.FastestManAlive) return;

        if (!_playerMovement) return;

        if (_playerMovement.GetMovementSpeed() >= 100f)
        {
            _achivementSO.FastestManAlive = true;
            Achievement achievement = _achievements.Find(a => a.name == "FastestManAliveAchievement");
            achievement.Unlock();
            _popupManager.ShowPopup(achievement.GetName, achievement.GetIcon);        }
    }

    public void CheckBadGraphics(float renderValue)
    {
        if (_achivementSO.BadGraphics) return;

        if (renderValue <= 0.1f)
        {
            _achivementSO.BadGraphics = true;
            Achievement achievement = _achievements.Find(a => a.name == "BadGraphicsAchievement");
            achievement.Unlock();
            _popupManager.ShowPopup(achievement.GetName, achievement.GetIcon);        }
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
            Achievement achievement = _achievements.Find(a => a.name == "DoesWhateverASpiderCanAchievement");
            achievement.Unlock();
            _popupManager.ShowPopup(achievement.GetName, achievement.GetIcon);        }
    }

    public void CheckYoureNotSupposedToGoThere()
    {
        if (_achivementSO.YoureNotSupposedToGoThere) return;

        _achivementSO.YoureNotSupposedToGoThere = true;
            Achievement achievement = _achievements.Find(a => a.name == "YoureNotSupposedToGoThereAchievement");
            achievement.Unlock();
            _popupManager.ShowPopup(achievement.GetName, achievement.GetIcon);    }

    public void CheckRageQuitter()
    {
        if (_achivementSO.RageQuitter) return;

        if (_counterSO.DeathCounter >= 1 && _counterSO.QuitThrooughPause == true)
        {
            _achivementSO.RageQuitter = true;
            Achievement achievement = _achievements.Find(a => a.name == "RageQuitterAchievement");
            achievement.Unlock();
            _popupManager.ShowPopup(achievement.GetName, achievement.GetIcon);        }
    }

    public void CheckYouShouldNotMakeAGame()
    {
        if (_achivementSO.YouShouldNotMakeAGame) return;

        if (_achivementSO.AllUnlocked)
        {
            _achivementSO.YouShouldNotMakeAGame = true;
            Achievement achievement = _achievements.Find(a => a.name == "YouShouldNotMakeAGameAchievement");
            achievement.Unlock();
            _popupManager.ShowPopup(achievement.GetName, achievement.GetIcon);        }
    }
}
