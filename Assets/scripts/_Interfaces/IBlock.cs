using UnityEngine;

enum en_PieceType
{
    brick,
    armed,
    tree,
    water,
    ice,
}

enum en_BonusType
{
    Bomb, 
    Shield, 
    EagleShield, 
    Star, 
    Life, 
    Freezing,
}

enum en_TankType
{
    Player,
    Enemy_1,
    Enemy_2,
    Enemy_3,
    Enemy_4,
}

interface IBlock
{
    void SetPieceType(en_PieceType type);
    void SetMaskPosition(Vector3 position);


}