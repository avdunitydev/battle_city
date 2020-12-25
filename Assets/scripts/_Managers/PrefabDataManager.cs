using System.Collections.Generic;
using UnityEngine;

class PrefabDataManager
{
    static readonly Dictionary<char, string> pathsToPrefabs = new Dictionary<char, string>
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
   
    internal static GameObject GetPrefab(char blockSymbol) => Resources.Load<GameObject>(pathsToPrefabs[blockSymbol]);
}
