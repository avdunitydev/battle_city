using UnityEngine;

class Level
{
    public readonly Vector2Int graphicBlockSize = new Vector2Int(8, 8);

    public char[,] LevelPrototype { get; private set; }

    
    public Level(char[,] levelPrototype)
    {
        LevelPrototype = levelPrototype;

    }


}

