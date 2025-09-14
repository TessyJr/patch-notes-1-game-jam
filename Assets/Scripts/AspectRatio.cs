using UnityEngine;

public class AspectRatio : MonoBehaviour
{
    [SerializeField] private float targetAspectRatio = 16f / 9f;
    [SerializeField] private Camera _camera;

    private float _lastScreenWidth;
    private float _lastScreenHeight;

    void Awake()
    {
        SetCameraAspect();
    }

    void SetCameraAspect()
    {
        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / targetAspectRatio;

        if (scaleHeight < 1.0f)
        {
            _camera.rect = new Rect(0, (1.0f - scaleHeight) / 2.0f, 1.0f, scaleHeight);
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            _camera.rect = new Rect((1.0f - scaleWidth) / 2.0f, 0, scaleWidth, 1.0f);
        }
    }

    void Update()
    {
        if (_lastScreenWidth != Screen.width || _lastScreenHeight != Screen.height)
        {
            SetCameraAspect();
            _lastScreenWidth = Screen.width;
            _lastScreenHeight = Screen.height;
        }
    }
}
