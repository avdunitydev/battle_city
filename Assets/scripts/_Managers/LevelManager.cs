using System;
using System.Collections.Generic;
using UnityEngine;

class LevelManager : Singleton<LevelManager>
{
    public GameObject wrapperLevel;

    public Level ActiveLevel { get; private set; }

    public List<BaseTank> Players { get; private set; } = new List<BaseTank>();


    readonly IStorageLevelsPrototypes storageLevelsPrototypes = new LocalStorageLevelsPrototypes();


    public void InstantiateLevel(int level_id)
    {
        ActiveLevel = storageLevelsPrototypes.GetLevelPrototype(level_id);

        char[,] tmp = ActiveLevel.LevelPrototype;

        for (int y = 0; y < tmp.GetLength(1); ++y)
        {
            for (int x = 0; x < tmp.GetLength(1); ++x)
            {
                if (tmp[y, x] != '.') BlockFactory.InstantiateBlock(tmp[y, x], x, y, this);
            }
        }
    }

    public void SetPlayer(BaseTank player)
    {
        Players.Add(player);
    }

    public void SetEnemies(BaseTank enemy)
    {
        //ActiveLevel.LevelEnemies_queue.Add(enemy);
    }


}

