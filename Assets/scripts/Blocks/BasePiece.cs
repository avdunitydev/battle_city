using System;
using System.Collections.Generic;
using UnityEngine;


class BasePiece : MonoBehaviour
{
    public en_PieceType PieceType { get; private set; }


    protected SpriteRenderer srPiece;
    protected Collider2D collider2D;
    protected SpriteMask spriteMask;

    protected virtual void Init()
    {
        srPiece = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
        spriteMask = GetComponentInChildren<SpriteMask>();

    }

    public void SetPieceType(en_PieceType type)
    {
        PieceType = type;
    }
    public void SetMaskPosition(Vector3 position)
    {
        spriteMask.transform.position = position;
    }

  


}
