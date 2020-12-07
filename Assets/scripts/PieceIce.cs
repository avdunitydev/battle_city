using UnityEngine;

class PieceIce : BasePiece, IBlock
{
    public Sprite spritePiece;

    
    protected override void Init()
    {
        base.Init();
        SetPieceType(en_PieceType.ice);
        srPiece.sprite = spritePiece;
    }



    private void Start()
    {
        Init();

    }
}