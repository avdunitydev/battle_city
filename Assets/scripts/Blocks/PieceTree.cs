using UnityEngine;

class PieceTree : BasePiece, IBlock
{
    public Sprite spritePiece;

    
    protected override void Init()
    {
        base.Init();
        SetPieceType(en_PieceType.tree);
        srPiece.sprite = spritePiece;
    }



    private void Start()
    {
        Init();
    }
}