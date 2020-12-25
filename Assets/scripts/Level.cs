using System.Collections.Generic;
using UnityEngine;

class Level
{
    int blockSize = 8;
    
    public Vector2Int GraphicBlockSize { get => new Vector2Int(blockSize, blockSize); }

    public char[,] LevelPrototype { get; private set; }

    public Queue<EnemyTank> LevelEnemies_queue { get; private set; }

    public List<Vector2> EnemiesSpawnPoints_list { get; private set; }

    public List<Vector2> PlayersSpawnPoints_list { get; private set; }

    internal Level(char[,] levelPrototype)
    {
        LevelPrototype = levelPrototype;

    }

    public void SetEnemySpawnPoint(Vector2 point) => EnemiesSpawnPoints_list.Add(point);
    public void SetPlayerSpawnPoint(Vector2 point) => PlayersSpawnPoints_list.Add(point);
    public void SetEnemy(EnemyTank enemies) => LevelEnemies_queue.Enqueue(enemies);

}

