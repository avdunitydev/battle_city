using UnityEngine;

class PieceBrick : BasePiece, IBlock
{
    public static readonly char symbolBlock = '#';

    public Sprite[] spritePiece = new Sprite[2];

   
    protected override void Init()
    {
        base.Init();
        SetPieceType(en_PieceType.brick);
        srPiece.sprite = spritePiece[0];
    }

    private void Start()
    {
        Init();

    }
}