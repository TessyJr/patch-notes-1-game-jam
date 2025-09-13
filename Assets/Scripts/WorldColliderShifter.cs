using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldColliderShifter : MonoBehaviour
{
    [SerializeField] private CompositeCollider2D _compositeCollider;
    [SerializeField] private WorldSettingScriptableObject _worldSettingSO;
    [SerializeField] private bool _increaseScale = false;

    void Start()
    {
        if (_worldSettingSO.WrongOffset)
        {
            if (_increaseScale)
            {
                transform.localScale = new(1.2f, 1.2f, 0);
            }
            else
            {
                _compositeCollider.offset = new(-1, 1);
            }
        }
    }
}
