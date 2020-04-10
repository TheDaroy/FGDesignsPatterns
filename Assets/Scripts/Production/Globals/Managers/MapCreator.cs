using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    public MapManager manager;
   
    public void CreateMap(TileType[][] mapData)
    {

        for (int i = 0; i < manager.TileSpawnList.Length; i++)
        {
            if (manager.TileSpawnList[i].pool == null)
            {
                manager.TileSpawnList[i].InitiatePool(manager.transform);
                if (manager.TileSpawnList[i].TowerInfo)
                {
                    if (manager.TileSpawnList[i].TowerInfo.Projectile.pool == null)
                    {
                        Debug.Log("Testing");
                        manager.TileSpawnList[i].TowerInfo.Projectile.InitiatePool();
                    }
                    
                }
            }
        }
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
                GameObject tempTile = manager.TileSpawnList[i].pool.GetUnit(true);
                tempTile.transform.position = new Vector3(y * 2, 0, x * 2);
                tempTile.transform.rotation = Quaternion.identity;
                Tile tile = tempTile.GetComponent<Tile>();
                manager.Reset += tile.DeSpawn;
                tempTile.name = (x.ToString() + " : " + y.ToString());

                if (manager.TileSpawnList[i].TowerInfo)
                {
                    Tower tower = tempTile.GetComponent<Tower>();
                    Debug.Log(manager.TileSpawnList[i].TowerInfo.Projectile.pool);
                   
                    tower.attackSpeed = manager.TileSpawnList[i].TowerInfo.AttackSpeed;               
                }
                break;
            }
        }
    }

}
