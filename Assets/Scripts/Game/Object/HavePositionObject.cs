using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HavePositionObject : MonoBehaviour, IHavingPosition
{
    public static float STEP = 2.10f;

    [SerializeField]
    private Vector2Int _position = default;
    public Vector2Int Position
    {
        get => _position;
        protected set => _position = value;
    }


    public void Stand(int width, int height)
    {
        var position = transform.localPosition;

        var max = width / 2f - .5f;
        max = -max;
        position.x = (max + Position.x) * STEP;

        max = height / 2f - .5f;
        position.y = (max - Position.y) * STEP;

        transform.localPosition = position;
    }
}
