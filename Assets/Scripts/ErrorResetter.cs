using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorResetter : MonoBehaviour
{
    [SerializeField] private PlayerSettingScriptableObject _playerSettingSO;
    [SerializeField] private WorldSettingScriptableObject _worldSettingSO;

    void Awake()
    {
        _playerSettingSO.Reset();
        _worldSettingSO.Reset();
        
        QualitySettings.vSyncCount = 1;
    }
}
