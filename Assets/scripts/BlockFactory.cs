using System.Collections.Generic;
using UnityEngine;

class BlockFactory : MonoBehaviour
{
    private static readonly Dictionary<char, string> pathsToPrefabs = new Dictionary<char, string>
    {
        {'#', "Prefabs/pieceBrick"},
        {'@', "Prefabs/pieceArmed"},
        {'%', "Prefabs/pieceTree"},
        {'~', "Prefabs/pieceWater"},
        {'-', "Prefabs/pieceIce"},
        {'p', "Prefabs/P1"},
        {'s', "Prefabs/spawn"},
        {'F', "Prefabs/flag"},
    };
    private static GameObject GetPrefab(char blockSymbol) => Resources.Load<GameObject>(pathsToPrefabs[blockSymbol]);



    public static void InstantiateBlock(char v, int posX, int posY, LevelManager manager)
    {
        GameObject go;

        if (v == 'F' || v == 'p' || v == 's')
        {
            go = Instantiate(GetPrefab(v), SetBlockPosition(posX, posY, manager), Quaternion.identity);
            if (v == 'p')
            {
                BaseTank p ;
                go.TryGetComponent<BaseTank>(out p);
                if (p)
                {
                    p.SetTankType(en_TankType.Player);
                    p.GetComponent<SpriteRenderer>().sprite = p.sprites[0];
                    p.SetSpeed(1f);
                    manager.SetPlayer(p);
                }
            }
        }
        else
        {
            go = Instantiate(GetPrefab(v), SetPiecePosition(posX, posY, manager), Quaternion.identity, manager.wrapperLevel.transform);

        }
    }

    private static Vector3 SetPiecePosition(float posX, float posY, LevelManager manager)
    {
        posX = posX / 100 * (float)manager.ActiveLevel.graphicBlockSize.x;
        posY = posY / 100 * (float)manager.ActiveLevel.graphicBlockSize.y;
        posY -= ((float)manager.ActiveLevel.graphicBlockSize.y * ((float)manager.ActiveLevel.LevelPrototype.GetLength(0) - 1) / 100);

        return new Vector3(posX, -posY, 0);
    }

    private static Vector3 SetBlockPosition(float posX, float posY, LevelManager manager)
    {
        float offsetX = (float)manager.ActiveLevel.graphicBlockSize.x / 2 / 100;
        posX = posX / 100 * (float)manager.ActiveLevel.graphicBlockSize.x;
        posX += offsetX;
        
        float offsetY = (float)manager.ActiveLevel.graphicBlockSize.y / 2 / 100;
        posY = posY / 100 * (float)manager.ActiveLevel.graphicBlockSize.y;
        posY -= ((float)manager.ActiveLevel.graphicBlockSize.y * ((float)manager.ActiveLevel.LevelPrototype.GetLength(0) - 1) / 100);
        posY += offsetY;

        return new Vector3(posX, -posY, 0);
    }



}
