using System;
using System.Collections.Generic;
using MemoryTool;
using UnityEngine;

public class UnitManager : ManagerBase
{
    [SerializeField] MapManager mapManager;
     private PathFinder _pathFinder; public PathFinder pathFinder { get { return _pathFinder; } private set { _pathFinder = value; } }

    [SerializeField] private UnitSpawner spawner;
    public WaveHandler waveHandler;
    [SerializeField] private UnitObject[] unitSpawnList; public UnitObject[] UnitSpawnList { get { return unitSpawnList; } private set { unitSpawnList = value; } }

    public event Action Reset;
    private UnitType[][] cachedWaveData;
    int currentwave = 0;

    float tileheight;
    private void Awake()
    {
        Setup();
    }
    void Setup()
    {
        if (_pathFinder == null) _pathFinder = new PathFinder();
        if (spawner == null) spawner = gameObject.AddComponent<UnitSpawner>();
        if (spawner.Manager == null) spawner.Manager = this;
        if (unitSpawnList.Length == 0) Debug.Log("UnitSpawnList is Empty");
        if (waveHandler == null) waveHandler = new WaveHandler();
        if (waveHandler.manager == null) waveHandler.manager = this;
        {

        }
    }
    protected override void StateSwitch(object sender, GameState state)
    {
        base.StateSwitch(sender, state);
        switch (state)
        {
            case GameState.NewGame:                
                BuildPath(mainManager.GetTileData());
                cachedWaveData = mainManager.GetWaveData();               
                spawner.SpawnWave(cachedWaveData[currentwave]);
                waveHandler.WaveSetup(cachedWaveData[currentwave]);
                tileheight = mapManager.GetHeight(TileType.Path);
                break;
            case GameState.Restart:
                Reset?.Invoke();
                currentwave = 0;
                spawner.SpawnWave(cachedWaveData[currentwave]);
                waveHandler.WaveSetup(cachedWaveData[currentwave]);
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
        return AdjustForTileHeight(_pathFinder.GetVector(i));
    }
    public Vector3 GetEndGoal()
    {        
        return AdjustForTileHeight( _pathFinder.GetLastVector());
    }
    private Vector3 AdjustForTileHeight(Vector3 vector)
    {
        Vector3 newVector = vector;
        newVector.y += tileheight;
        return newVector;
    }
    public void NextWave()
    {
        currentwave++;
        spawner.SpawnWave(cachedWaveData[currentwave]);
        waveHandler.WaveSetup(cachedWaveData[currentwave]);
    }
    public void OnDeath()
    {
        mainManager.Restart();
    }
}
