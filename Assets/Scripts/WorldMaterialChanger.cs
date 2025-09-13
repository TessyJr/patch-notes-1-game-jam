using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldMaterialChanger : MonoBehaviour
{
    [SerializeField] private TilemapRenderer _tilemapRenderer;
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Material _material;
    [SerializeField] private WorldSettingScriptableObject _worldSettingSO;
    void Start()
    {
        if (_worldSettingSO.MissingTexture)
        {
            if (_tilemapRenderer != null) _tilemapRenderer.material = _material;

            if (_spriteRenderer != null) _spriteRenderer.material = _material;

            if (_tilemap != null) _tilemap.color = new(1, 0, 1, 1);
        }

    }
}
