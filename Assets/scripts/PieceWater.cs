using UnityEngine;

class PieceWater : BasePiece, IBlock
{
    public Sprite[] spritePiece = new Sprite[2];


    protected override void Init()
    {
        base.Init();
        SetPieceType(en_PieceType.water);
        srPiece.sprite = spritePiece[0];
    }



    private void Start()
    {
        Init();
    }

}
