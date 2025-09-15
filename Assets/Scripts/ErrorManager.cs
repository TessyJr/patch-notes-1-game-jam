using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using Cinemachine;

public class ErrorManager : MonoBehaviour
{
    [Header("Scriptable Object Settings")]
    [SerializeField] private WorldSettingScriptableObject _worldSettingSO;
    [SerializeField] private AchievementDetectionController _achivementDetectionController;

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

    [Header("Lighting Issue Error Settings")]
    [SerializeField] private Image blackScreen;
    [SerializeField] private float minLightingIssueInterval = 1f;
    [SerializeField] private float maxLightingIssueInterval = 2f;

    [Header("Inconsistent Friction Error Settings")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private float inconsistentFrictionInterval = 1f;
    [SerializeField] private float minFriction = 0f;
    [SerializeField] private float maxFriction = 1f;

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

        if (_worldSettingSO.LightingIssue)
        {
            StartCoroutine(LightingIssueRoutine());
        }

        if (_worldSettingSO.UnsteadyHands)
        {
            UnsteadyHands();
        }

        if (_worldSettingSO.InconsistentFriction)
        {
            StartCoroutine(InconsistentFrictionRoutine());
        }
    }

    private IEnumerator FrameDropRoutine()
    {
        QualitySettings.vSyncCount = 0; // make sure vsync isn't interfering

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

            _achivementDetectionController.CheckBadGraphics(currentScale);

            SetRenderScale(currentScale);
        }
    }

    private IEnumerator GravityFlipRoutine()
    {
        yield return new WaitForSeconds(gravityFlipInterval);

        while (_worldSettingSO.GravityFlip)
        {
            yield return new WaitUntil(() => playerMovement.IsGrounded);

            FlipGravity();

            yield return new WaitForSeconds(gravityFlipInterval);

            FlipGravity();
        }
    }

    private void FlipGravity()
    {
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

    private IEnumerator LightingIssueRoutine()
    {
        while (_worldSettingSO.LightingIssue)
        {
            float randomInterval = Random.Range(minLightingIssueInterval, maxLightingIssueInterval);
            yield return new WaitForSeconds(randomInterval);

            if (blackScreen.color.a > 0.5f) // Currently ON → flicker OFF
            {
                yield return StartCoroutine(FlickerSequence(new float[] { 0.25f, 0f, 0.5f, 0f, 0.75f, 1f }));
                SetAlpha(0f); // final state = OFF (clear screen)
            }
            else // Currently OFF → flicker ON
            {
                yield return StartCoroutine(FlickerSequence(new float[] { 1f, 0f, 0.75f, 0f, 0.5f, 0f, 0.25f, 0f }));
                SetAlpha(1f); // final state = ON (fully black)
            }
        }
    }

    private IEnumerator FlickerSequence(float[] alphaSteps)
    {
        foreach (float alpha in alphaSteps)
        {
            SetAlpha(alpha);
            yield return new WaitForSeconds(0.05f); // flicker speed
        }
    }

    private void SetAlpha(float alpha)
    {
        Color c = blackScreen.color;
        c.a = alpha;
        blackScreen.color = c;
    }

    private void UnsteadyHands()
    {
        _noise = _cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _noise.m_PivotOffset = new(5, 5, 5);
        _noise.m_AmplitudeGain = 5f;
        _noise.m_FrequencyGain = 5f;
    }

    private IEnumerator InconsistentFrictionRoutine()
    {
        while (_worldSettingSO.InconsistentFriction)
        {
            yield return new WaitForSeconds(inconsistentFrictionInterval);

            if (playerMovement != null && playerMovement.IsGrounded)
            {
                float randomSpeed = Random.Range(minFriction, maxFriction);
                playerMovement.SetFriction(randomSpeed);
            }
        }
    }
}
