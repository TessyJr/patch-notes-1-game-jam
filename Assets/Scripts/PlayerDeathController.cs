using UnityEngine;

public class PlayerDeathController : MonoBehaviour
{
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
