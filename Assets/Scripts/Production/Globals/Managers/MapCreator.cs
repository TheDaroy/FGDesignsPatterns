using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    public MapManager manager;
   
    public void CreateMap(TileType[][] mapData)
    {
        for (int x = 0; x < mapData.Length; x++)
        {
            for (int y = 0; y < mapData[x].Length -1; y++)
            {
                SpawnTile(x,y,mapData[x][y]);
            }
        }    
    }
    void SpawnTile(int x, int y, TileType type)
    {
        for (int i = 0; i < manager.TileSpawnList.Length; i++)
        {
            if (manager.TileSpawnList[i].Sign == type)
            {            
                GameObject tempTile = Instantiate(manager.TileSpawnList[i].Tile,new Vector3(y *2,0, x*2),Quaternion.identity,transform);
                tempTile.name = (x.ToString() + " : " + y.ToString());
                
                break;
            }
        }
    }

}
