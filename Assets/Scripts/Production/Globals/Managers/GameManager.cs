using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFunctions;
public class GameManager : MonoBehaviour
{
    [SerializeField] private TextAsset[] FileToRead;
    [SerializeField] private MapReader reader;

    
    
    public event EventHandler<GameState> state;
    private TileType[][] mapData;
    private UnitType[][] waveData;

    public int levelToLoad = 0;
    int currentLevel;
   
    private void Awake()
    {
        if (reader == null) reader = gameObject.AddComponent<MapReader>();
        currentLevel = levelToLoad;
        
    }

    public void NewGame()
    {
        LoadLevel(levelToLoad);
        state?.Invoke(this, GameState.NewGame);
    }
    public void Restart()
    {
        state?.Invoke(this, GameState.Restart);
    }
    public void NextLevel()
    {
        levelToLoad++;
        LoadLevel(levelToLoad);
        state?.Invoke(this, GameState.NextLevel);
    }

    public TileType[][] GetTileData()
    {
        return mapData;
    }
    public UnitType[][]  GetWaveData()
    {
        return waveData;
    }
    private void Start()
    {
        NewGame();
    }
    void LoadLevel(int levelToLoad)
    {
        reader.GetData(FileToRead[levelToLoad],  out mapData,  out waveData);

    }
}
