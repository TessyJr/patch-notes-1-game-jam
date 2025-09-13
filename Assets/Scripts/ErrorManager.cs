using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
using UnityEngine.Rendering.Universal;

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

    [Header("Quality Change Error Settings")]
    [SerializeField] private UniversalRenderPipelineAsset urpAsset;
    [SerializeField] private float stepInterval = 1f;       // how often to step down (seconds)
    [SerializeField] private float stepAmount = 0.1f;       // how much to reduce per step
    [SerializeField] private float minRenderScale = 0.1f;   // minimum allowed scale

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

        if (_worldSettingSO.QualityChange)
        {
            StartCoroutine(QualityStepDownRoutine());
        }
        else
        {
            urpAsset.renderScale = 1f;
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

    public void SetRenderScale(float scale)
    {
        urpAsset.renderScale = Mathf.Clamp(scale, minRenderScale, 1f);
    }

    private IEnumerator QualityStepDownRoutine()
    {
        float currentScale = 1f;
        SetRenderScale(currentScale);

        while (currentScale > minRenderScale)
        {
            yield return new WaitForSeconds(stepInterval);

            currentScale -= stepAmount;
            SetRenderScale(currentScale);
        }
    }
}
