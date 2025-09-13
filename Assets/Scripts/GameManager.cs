using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Performance Settings")]
    [Tooltip("Target FPS for the game. Set to -1 for platform default.")]
    public int targetFPS = 60;

    [Header("Frame Drop Mechanic")]
    [Tooltip("Enable the random frame drop mechanic.")]
    public bool enableFrameDropMechanic = false;

    [Tooltip("How often frame drops can happen (seconds).")]
    public float frameDropInterval = 1f;

    [Tooltip("Duration of the frame drop (seconds).")]
    public float frameDropDuration = 0.5f;

    [Tooltip("Target FPS during a frame drop.")]
    public int dropToFPS = 5;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        ApplySettings();

        if (enableFrameDropMechanic)
            StartCoroutine(FrameDropRoutine());
    }

    private void ApplySettings()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFPS;
    }

    public void SetTargetFPS(int fps)
    {
        targetFPS = fps;
        Application.targetFrameRate = targetFPS;
    }

    private IEnumerator FrameDropRoutine()
    {
        while (enableFrameDropMechanic)
        {
            yield return new WaitForSeconds(frameDropInterval);

            Application.targetFrameRate = dropToFPS;
            yield return new WaitForSeconds(frameDropDuration);

            Application.targetFrameRate = targetFPS;
        }
    }
}
