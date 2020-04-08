using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : ManagerBase
{

    [SerializeField] private PathFinder _pathFinder; public PathFinder pathFinder { get { return _pathFinder; } private set { _pathFinder = value; } }

    [SerializeField] private UnitSpawner spawner;
    [SerializeField] private UnitObject[] unitSpawnList; public UnitObject[] UnitSpawnList { get { return unitSpawnList; } private set { unitSpawnList = value; } }


    private UnitType[][] cachedWaveData;
    private void Awake()
    {
        Setup();
    }
    void Setup()
    {
        if (_pathFinder == null) _pathFinder = gameObject.AddComponent<PathFinder>();
        if (spawner == null) spawner = gameObject.AddComponent<UnitSpawner>();
        if (spawner.Manager == null) spawner.Manager = this;
        if (unitSpawnList.Length == 0) Debug.Log("UnitSpawnList is Empty"); 
    }
    protected override void StateSwitch(object sender, GameState state)
    {
        base.StateSwitch(sender, state);
        switch (state)
        {
            case GameState.NewGame:                
                BuildPath(mainManager.GetTileData());
                cachedWaveData = mainManager.GetWaveData();
                Debug.Log(cachedWaveData.Length);
                spawner.SpawnWave(cachedWaveData[0]);
                break;
            case GameState.Restart:
                break;
            case GameState.NextLevel:
                break;
            
        }
    }
 
    void BuildPath(TileType[][] mapData)
    {
        _pathFinder.BuildPath(mapData);
    }
    public Vector3 GetNewVector(int i)
    {
        return _pathFinder.GetVector(i);
    }
    public void UpdateWave(UnitType[][] newWaveData)
    {

    }
     void SpawnWave(int currentWave)
    {

    }
}
