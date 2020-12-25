using UnityEngine;

class PieceArmed : BasePiece, IBlock
{
    public Sprite spritePiece;

    protected override void Init()
    {
        base.Init();
        SetPieceType(en_PieceType.armed);
        srPiece.sprite = spritePiece;
    }


    private void Start()
    {
        Init();

    }


}