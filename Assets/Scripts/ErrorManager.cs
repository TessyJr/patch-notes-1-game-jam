using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;

public class ErrorManager : MonoBehaviour
{
    [Header("Scriptable Object Settings")]
    [SerializeField] private WorldSettingScriptableObject _worldSettingSO;

    [Header("FPS Drop Error Settings")]
    [SerializeField] private float frameDropInterval = 1f;
    [SerializeField] private float frameDropDuration = 0.5f;
    [SerializeField] private int dropToFPS = 5;

    [Header("Glitchy World Error Settings")]
    [SerializeField] private Material _glitchMaterial;
    [SerializeField] private SpriteRenderer[] _spriteRenderers;
    [SerializeField] private TilemapRenderer[] _tilemapRenderers;

    private void Awake()
    {
        if (_worldSettingSO.FPSDrop)
        {
            StartCoroutine(FrameDropRoutine());
        }

        if (_worldSettingSO.GlitchyWorld)
        {
            foreach (SpriteRenderer _spriteRenderer in _spriteRenderers)
            {
                _spriteRenderer.material = _glitchMaterial;
            }

            foreach (TilemapRenderer _tilemapRenderer in _tilemapRenderers)
            {
                _tilemapRenderer.material = _glitchMaterial;
            }
        }
    }

    private IEnumerator FrameDropRoutine()
    {
        while (_worldSettingSO.FPSDrop)
        {
            yield return new WaitForSeconds(frameDropInterval);

            Application.targetFrameRate = dropToFPS;
            yield return new WaitForSeconds(frameDropDuration);

            Application.targetFrameRate = -1;
        }
    }
}
