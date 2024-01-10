using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private Game _game = default;

    [SerializeField]
    private int _width = default;
    [SerializeField]
    private int _height = default;

    [SerializeField]
    private Player _player = default;
    [SerializeField]
    private Block[] _blocks = default;
    [SerializeField]
    private Wall[] _walls = default;
    [SerializeField]
    private Target[] _targets = default;
    [SerializeField]
    private Trap[] _traps = default;
    [SerializeField]
    private HavePositionObject[] _anotherObjects = default;

    private Control _control = default;

    private HavePositionObject[] allObjects = null;
    private HavePositionObject[] _allObjects
    {
        get
        {
            if (allObjects == null)
            {
                var objects = new List<HavePositionObject>();
                objects.Add(_player);
                objects.AddRange(_blocks);
                objects.AddRange(_walls);
                objects.AddRange(_targets);
                objects.AddRange(_traps);
                objects.AddRange(_anotherObjects);
                allObjects = objects.ToArray();
            }
            return allObjects;
        }
    }


    public void Init(Game game, Control control)
    {
        _game = game;

        _control = control;
        _player.Init(this, _control);
        foreach (var block in _blocks)
        {
            block.Init(this, _control);
        }
    }

    public void StandObjects()
    {
        foreach (var obj in _allObjects)
        {
            obj.Stand(_width, _height);
        }
    }

    public bool IsEnableForPlayer(Vector2Int position)
    {
        foreach (var wall in _walls)
        {
            if (wall.Position == position)
            {
                return false;
            }
        }
        foreach (var trap in _traps)
        {
            if (trap.Position == position)
            {
                Lose();
                return true;
            }
        }
        foreach (var block in _blocks)
        {
            if (block.Position == position)
            {
                if ((block.IsCanMove(position + _control.DirectionYInverted)))
                {
                    block.Move(position + _control.DirectionYInverted);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        return true;
    }

    public bool IsEnableForBlock(Vector2Int position)
    {
        foreach (var wall in _walls)
        {
            if (wall.Position == position)
            {
                return false;
            }
        }
        foreach (var trap in _traps)
        {
            if (trap.Position == position)
            {
                Lose();
                return true;
            }
        }
        foreach (var block in _blocks)
        {
            if (block.Position == position)
            {
                return false;
            }
        }
        return true;
    }

    public bool IsBlockOnTarget(Vector2Int position)
    {
        foreach (var target in _targets)
        {
            if (target.Position == position)
            {
                return true;
            }
        }
        return false;
    }

    private bool CheckWin()
    {
        foreach (var target in _targets)
        {
            bool isEmpty = true;
            foreach (var block in _blocks)
            {
                if (target.Position == block.Position)
                {
                    isEmpty = false;
                    break;
                }
            }

            if (isEmpty)
            {
                return false;
            }
        }
        return true;
    }

    public void CheckTargets()
    {
        if (CheckWin())
        {
            Win();
        }
    }

    private void Win()
    {
        _game.Win();
    }

    private void Lose()
    {
        StartCoroutine(Losing());
    }

    private IEnumerator Losing()
    {
        yield return new WaitForSeconds(.25f);
        _game.Lose();
    }
}
