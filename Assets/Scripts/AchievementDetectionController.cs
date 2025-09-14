using UnityEngine;

public class AchievementDetectionController : MonoBehaviour
{
    [SerializeField] private PlayerSettingScriptableObject _playerSettingSO;
    [SerializeField] private WorldSettingScriptableObject _worldSettingSO;
    [SerializeField] private AchievementScriptableObject _achivementSO;
    [SerializeField] private CounterScriptableObject _counterSO;

    [Header("Ground Is Not Where I Stand Settings")]
    [SerializeField] private PlayerMovement _playerMovement;
    private float _airTime = 0f;
    private float _wallTime = 0f;

    void Start()
    {
        CheckFailedTheQC();

        CheckAProperGame();
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

    public void CheckSpeedrunner()
    {
        if (_achivementSO.SpeedRunner) return;

        if (Time.time <= 5.5f)
        {
            _achivementSO.SpeedRunner = true;
        }
    }

    public void CheckGroundIsNotWhereIStand()
    {
        if (_achivementSO.GroundIsNotWhereIStand) return;

        if (_playerMovement.IsGrounded)
        {
            _airTime = 0f;
            return;
        }

        _airTime += Time.deltaTime;

        if (_airTime >= 3f)
        {
            _achivementSO.GroundIsNotWhereIStand = true;
        }
    }

    public void CheckFastestManAlive()
    {
        if (_achivementSO.FastestManAlive) return;

        if (_playerMovement.GetMovementSpeed() >= 100f)
        {
            _achivementSO.FastestManAlive = true;
        }
    }

    public void CheckBadGraphics(float renderValue)
    {
        if (_achivementSO.BadGraphics) return;

        if (renderValue <= 0.1f)
        {
            _achivementSO.BadGraphics = true;
        }
    }

    public void CheckDoesWhateverASpiderCan()
    {
        if (_achivementSO.DoesWhateverASpiderCan) return;

        if (_playerMovement.IsGrounded || !_playerMovement.IsStickToWall)
        {
            _wallTime = 0f;
            return;
        }

        _wallTime += Time.deltaTime;

        if (_wallTime >= 3f)
        {
            _achivementSO.DoesWhateverASpiderCan = true;
        }
    }

    public void CheckYoureNotSupposedToGoThere()
    {
        if (_achivementSO.YoureNotSupposedToGoThere) return;

        _achivementSO.YoureNotSupposedToGoThere = true;
    }

    public void CheckRageQuitter()
    {
        if (_achivementSO.RageQuitter) return;

        if (_counterSO.DeathCounter >= 1)
        {
            _achivementSO.RageQuitter = true;
        }
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
