using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    private const float RATIO = 2484f / 4416f;
    private float _defaultSize = default;
    private Camera _camera = default;

    private void Awake()
    {
        Init();
        SetScale();
    }

#if UNITY_EDITOR
    private void Update()
    {
        SetScale();
    }
#endif

    private void Init()
    {
        _camera = GetComponent<Camera>();
        _defaultSize = _camera.orthographicSize;
    }

    private void SetScale()
    {
        var ratio = (float)Screen.width / Screen.height;
        _camera.orthographicSize = (RATIO / ratio) * _defaultSize;
    }
}
