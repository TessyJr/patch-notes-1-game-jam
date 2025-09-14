using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldMaterialChanger : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private TileBase _noMaterialTile;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private WorldSettingScriptableObject _worldSettingSO;
    void Start()
    {
        if (_worldSettingSO.MissingTexture)
        {
            if (_spriteRenderer != null)
            {
                _spriteRenderer.color = new(1, 0, 1, 1);

                if (_animator && _worldSettingSO.GlitchyWorld == false) _animator.enabled = false;

                if (_sprite && _worldSettingSO.GlitchyWorld == false) _spriteRenderer.sprite = _sprite;
            }

            if (_tilemap != null)
            {
                _tilemap.color = new(1, 0, 1, 1);

                if(_noMaterialTile && _worldSettingSO.GlitchyWorld == false) ReplaceAllTiles(_noMaterialTile);
            }
        }

    }

    private void ReplaceAllTiles(TileBase newTile)
    {
        BoundsInt bounds = _tilemap.cellBounds;
        foreach (var pos in bounds.allPositionsWithin)
        {
            if (_tilemap.HasTile(pos))
            {
                _tilemap.SetTile(pos, newTile);
            }
        }
    }
}
