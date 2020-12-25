using UnityEngine;

internal class BlockFactory : MonoBehaviour
{
    static int playerCounter = 0;
    public static void InstantiateBlock(char v, int posX, int posY, LevelManager manager)
    {
        GameObject go;

        if (v == 'F' || v == 'p' || v == 's')
        {
            go = Instantiate(PrefabDataManager.GetPrefab(v), SetBlockPosition(posX, posY, manager), Quaternion.identity);
            if (v == 'p')
            {
                PlayerTank p;
                go.TryGetComponent<PlayerTank>(out p);

                if (p)
                {
                    ++playerCounter;
                    if(playerCounter < 2) p.SetFirst(true);

                    p.SetTankType(en_TankType.Player);
                    p.GetComponent<SpriteRenderer>().sprite = (p.FirstPlayer) ? p.sprites[0] : p.sprites[1];
                    p.SetSpeed(1f);
                    manager.SetPlayer(p);
                }
            }
        }
        else
        {
            go = Instantiate(PrefabDataManager.GetPrefab(v), SetPiecePosition(posX, posY, manager), Quaternion.identity, manager.wrapperLevel.transform);

        }
    }

    private static Vector3 SetPiecePosition(float posX, float posY, LevelManager manager)
    {
        posX = posX / 100 * (float)manager.ActiveLevel.GraphicBlockSize.x;
        posY = posY / 100 * (float)manager.ActiveLevel.GraphicBlockSize.y;
        posY -= ((float)manager.ActiveLevel.GraphicBlockSize.y * ((float)manager.ActiveLevel.LevelPrototype.GetLength(0) - 1) / 100);

        return new Vector3(posX, -posY, 0);
    }

    private static Vector3 SetBlockPosition(float posX, float posY, LevelManager manager)
    {
        float offsetX = (float)manager.ActiveLevel.GraphicBlockSize.x / 2 / 100;
        posX = posX / 100 * (float)manager.ActiveLevel.GraphicBlockSize.x;
        posX += offsetX;

        float offsetY = (float)manager.ActiveLevel.GraphicBlockSize.y / 2 / 100;
        posY = posY / 100 * (float)manager.ActiveLevel.GraphicBlockSize.y;
        posY -= ((float)manager.ActiveLevel.GraphicBlockSize.y * ((float)manager.ActiveLevel.LevelPrototype.GetLength(0) - 1) / 100);
        posY += offsetY;

        return new Vector3(posX, -posY, 0);
    }



}
