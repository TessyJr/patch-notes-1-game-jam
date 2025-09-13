using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderShifter : MonoBehaviour
{
    [SerializeField] private PlayerSettingScriptableObject _playerSettingSO;
    void Start()
    {
        if (_playerSettingSO.ShiftedHitbox)
        {
            transform.localPosition = new(-1, -0.5f, 0);
        }
    }
}
