using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] private PathFinder pathFinder;

    [SerializeField] private MapManager mapManager;
    private void Start()
    {
        Enemy temp = Instantiate(enemy);
        temp.manager = this;
        //BuildPath(mapManager.MapData);
    }

    void BuildPath(TileType[][] mapData)
    {
        pathFinder.BuildPath( mapData);
    }
    public Vector3 GetNewVector(int i)
    {
        return pathFinder.GetVector(i);
    }
}
