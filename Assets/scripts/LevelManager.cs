using System;
using System.Collections.Generic;
using UnityEngine;

class LevelManager : MonoBehaviour
{
    [SerializeField]
    private int LEVEL_NUM;
    public Level ActiveLevel { get; private set; }

    public GameObject wrapperLevel;

    public BaseTank Player { get; private set; }
    public List<BaseTank> Enemies { get; private set; } = new List<BaseTank>();


    readonly IStorageLevelsPrototypes storageLevelsPrototypes = new LocalStorageLevelsPrototypes();


    void InstantiateLevel(int level_id)
    {
        ActiveLevel = new Level(storageLevelsPrototypes.GetLevelPrototype(level_id));
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
        Player = player;
    }

    public void SetEnemies(BaseTank enemy)
    {
        Enemies.Add(enemy);
    }

    private void Awake()
    {
        InstantiateLevel(LEVEL_NUM);
    }

}

