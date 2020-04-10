using System;
using UnityEngine;

public class MapManager : ManagerBase
{
    [SerializeField] private MapCreator creator;
    #region Map Variables   
    [Header("Map Variables")]
    private TileType[][] cachedMapData; 
    [SerializeField] private TileObject[] tileSpawnList; public TileObject[] TileSpawnList { get { return tileSpawnList; } private set { tileSpawnList = value; } }
    
    #endregion
    public event Action<MapManager> Reset;
    private void Awake()
    {
        Setup();
    }
    void Setup()
    {       
        if (creator == null) creator = gameObject.AddComponent<MapCreator>();
        if (creator.manager == null) creator.manager = this;  
    }

    protected override void StateSwitch(object sender, GameState state)
    {
        base.StateSwitch(sender, state);
        switch (state)
        {
            case GameState.NewGame:
                UpdateMapData(mainManager.GetTileData());
                CreateMap();
                break;
            case GameState.Restart:
                Reset?.Invoke(this);
                CreateMap();
                break;
            case GameState.NextLevel:
                Reset?.Invoke(this);
                UpdateMapData(mainManager.GetTileData());
                CreateMap();
                break;
        }
    }

    void CreateMap()
    {
        creator.CreateMap(cachedMapData);
    }

    public void UpdateMapData(TileType[][] newMapData)
    {
        cachedMapData = newMapData;       
    }

   
}
