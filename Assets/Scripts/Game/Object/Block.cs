using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : HavePositionObject, IMovable
{
    private Level _level = default;
    private Control _control = default;

    private SpriteRenderer spriteRenderer = null;
    private SpriteRenderer _spriteRenderer => spriteRenderer ??= GetComponent<SpriteRenderer>();
    private bool isOnTarget = false;
    private bool _isOnTarget
    {
        get => isOnTarget;
        set
        {
            isOnTarget = value;

            _spriteRenderer.color = value ? new Color(0, 1, 1, 1) : Color.white;
        }
    }


    private void Start()
    {
        CheckTargets();
    }

    public void Init(Level level, Control control)
    {
        _level = level;
        _control = control;
    }

    public void Move()
    {

    }

    public void Move(Vector2Int position)
    {
        StartCoroutine(Moving(position));
    }

    public bool TryMove()
    {
        return false;
    }

    public bool IsCanMove(Vector2Int position)
    {
        return _level.IsEnableForBlock(position);
    }

    private IEnumerator Moving(Vector2Int position)
    {
        var startPosition = transform.localPosition;
        var targetPosition = startPosition + new Vector3(_control.Direction.x, _control.Direction.y, 0) * STEP;

        Position += _control.DirectionYInverted;
        float time = .3f;
        for (float t = 0f; t < time; t += Time.deltaTime)
        {
            transform.localPosition = Vector3.Lerp(startPosition, targetPosition, t / time);
            yield return null;
        }
        transform.localPosition = targetPosition;

        yield return null;

        CheckTargets();
    }

    private void CheckTargets()
    {
        _isOnTarget = _level.IsBlockOnTarget(Position);
        _level.CheckTargets();
    }
}
