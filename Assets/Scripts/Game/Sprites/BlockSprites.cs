using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BlockSpriteSet
{
    public Sprite[] Sprites;
}

public class BlockSprites : MonoBehaviour
{
    public static BlockSpriteSet[] Sets = default;
    public static BlockSpriteSet Set => Sets[CurrentSetId];
    [SerializeField]
    private BlockSpriteSet[] _sets = default;
    public static int CurrentSetId = 0;

    private void Awake()
    {
        CurrentSetId = Product.GetCurrentId();
        Product.OnSetCurrentId.AddListener((id) => { CurrentSetId = id; });
        Sets = _sets;
    }
}
