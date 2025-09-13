using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
using UnityEngine.Rendering.Universal;
using Cinemachine;

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
    [SerializeField] private float qualityStepInterval = 0.75f;
    [SerializeField] private float qualityStepAmount = 0.1f;
    [SerializeField] private float minRenderScale = 0.1f;

    [Header("Gravity Flip Error Settings")]
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float gravityFlipInterval = 1f;

    [Header("Unsteady Hands Error Settings")]
    [SerializeField] private CinemachineVirtualCamera _cinemachine;
    private CinemachineBasicMultiChannelPerlin _noise;

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

        if (_worldSettingSO.GravityFlip)
        {
            StartCoroutine(GravityFlipRoutine());
        }

        if (_worldSettingSO.UnsteadyHands)
        {
            UnsteadyHands();
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
            yield return new WaitForSeconds(qualityStepInterval);

            currentScale -= qualityStepAmount;
            SetRenderScale(currentScale);
        }
    }

    private IEnumerator GravityFlipRoutine()
    {
        while (_worldSettingSO.GravityFlip)
        {
            yield return new WaitForSeconds(gravityFlipInterval);

            if (playerRigidbody != null)
            {
                playerRigidbody.gravityScale *= -1f;
            }

            if (playerTransform != null)
            {
                Vector3 scale = playerTransform.localScale;
                scale.y *= -1f;
                playerTransform.localScale = scale;
            }
        }
    }

    private void UnsteadyHands()
    {
        _noise = _cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _noise.m_PivotOffset = new(5, 5, 5);
        _noise.m_AmplitudeGain = 5f;
        _noise.m_FrequencyGain = 5f;
    }
}
