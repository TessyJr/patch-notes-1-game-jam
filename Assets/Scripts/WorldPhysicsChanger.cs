using UnityEngine;

public class WorldPhysicsChanger : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private WorldSettingScriptableObject _worldSettingSO;
    void Start()
    {
        if (_worldSettingSO.PhysicsGoneWild && _rb)
        {
            _rb.bodyType = RigidbodyType2D.Dynamic;
            _rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }
}
