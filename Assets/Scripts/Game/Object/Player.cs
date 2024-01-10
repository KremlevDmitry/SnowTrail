using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : HavePositionObject, IMovable
{
    private Level _level = default;
    private Control _control = default;

    private bool _isAnim = false;


    public void Init(Level level, Control control)
    {
        _level = level;

        _control = control;
        _control.OnSetDirection.AddListener(StartMove);
    }

    public void Move()
    {
        
    }

    public bool TryMove()
    {
        return _level.IsEnableForPlayer(Position + _control.DirectionYInverted);
    }

    private void StartMove()
    {
        StartCoroutine(Moving());
    }

    private IEnumerator Moving()
    {
        var startPosition = transform.localPosition;
        var targetPosition = startPosition + new Vector3(_control.Direction.x, _control.Direction.y, 0) * STEP;
        if (startPosition.x != targetPosition.x)
        {
            var scale = transform.localScale;
            scale.x = startPosition.x > targetPosition.x ? 1f : -1f;
            transform.localScale = scale;
        }

        if (_isAnim) { yield break; }
        if (!TryMove()) { yield break; }

        _isAnim = true;
        Position += _control.DirectionYInverted;
        float time = .3f;
        for (float t = 0f; t < time; t += Time.deltaTime)
        {
            transform.localPosition = Vector3.Lerp(startPosition, targetPosition, t / time);
            yield return null;
        }
        transform.localPosition = targetPosition;
        _isAnim = false;


        if (_control.Direction != Vector2Int.zero)
        {
            StartMove();
        }
    }
}
