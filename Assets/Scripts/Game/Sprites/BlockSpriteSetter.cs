using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpriteSetter : MonoBehaviour
{
    [SerializeField]
    private int _id = default;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = BlockSprites.Set.Sprites[_id];
    }
}
