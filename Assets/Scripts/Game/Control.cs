using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Control : MonoBehaviour, IPointerDownHandler, IPointerMoveHandler, IPointerUpHandler
{
    private Vector2Int direction = new(0, 0);
    public Vector2Int Direction
    {
        get => direction;
        set
        {
            direction = value;
            if (value != Vector2Int.zero)
            {
                OnSetDirection.Invoke();
            }
        }
    }
    public Vector2Int DirectionYInverted
    {
        get
        {
            var direction = Direction;
            direction.y = -direction.y;
            return direction;
        }
    }
    private bool isDown = false;
    private Vector2 _startPosition = default;
    public UnityEvent OnSetDirection = new();


    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
        _startPosition = eventData.position;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (!isDown) { return; }
        var position = eventData.position;
        var deltaX = _startPosition.x - position.x;
        var deltaY = _startPosition.y - position.y;

        if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
        {
            if (deltaX > 0)
            {
                if (direction != new Vector2Int(-1, 0))
                {
                    _startPosition = eventData.position;
                }
                Direction = new Vector2Int(-1, 0);
            }
            else if (deltaX < 0)
            {
                if (direction != new Vector2Int(1, 0))
                {
                    _startPosition = eventData.position;
                }
                Direction = new Vector2Int(1, 0);
            }
        }
        else
        {
            if (deltaY > 0)
            {
                if (direction != new Vector2Int(0, -1))
                {
                    _startPosition = eventData.position;
                }
                Direction = new Vector2Int(0, -1);
            }
            else if (deltaY < 0)
            {
                if (direction != new Vector2Int(0, 1))
                {
                    _startPosition = eventData.position;
                }
                Direction = new Vector2Int(0, 1);
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
        Direction = new Vector2Int(0, 0);
    }

#if UNITY_EDITOR

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Direction = new Vector2Int(1, 0);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Direction = new Vector2Int(0, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Direction = new Vector2Int(-1, 0);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Direction = new Vector2Int(0, 0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Direction = new Vector2Int(0, 1);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Direction = new Vector2Int(0, 0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Direction = new Vector2Int(0, -1);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Direction = new Vector2Int(0, 0);
        }
    }

#endif
}
