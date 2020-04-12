using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AI;
using UnityEngine;

public class PathFinder 
{
    
    List<Vector2Int> accessibles = new List<Vector2Int>();
    IEnumerable<Vector2Int> path;
    Vector2Int end;
    Vector2Int start;


    public void BuildPath(TileType[][] mapData)
    {
        accessibles.Clear();
        GetPathData(mapData);
        FindPath(end, start);
    }
    void GetPathData(TileType[][] mapData)
    {      
        for (int x = 0; x < mapData.Length; x++)
        {          
            for (int y = 0; y < mapData[x].Length - 1; y++)
            {               
                if (TileMethods.IsWalkable(mapData[x][y]))
                {                
                    switch (mapData[x][y])
                    {
                        case TileType.Path:                           
                            accessibles.Add(new Vector2Int(x, y));
                            break;
                        case TileType.Start:                        
                            end = new Vector2Int(x,y);
                            accessibles.Add(end);
                            break;
                        case TileType.End:
                            start = new Vector2Int(x, y);
                            accessibles.Add(start);
                            break;
                        default:
                            break;
                    }
                }               
            }
        }   
    }
    void FindPath(Vector2Int startTile, Vector2Int endTile)
    {
        IPathFinder pathFinder = new Dijkstra(accessibles);
        path = pathFinder.FindPath(startTile, endTile);

        
    }
   public Vector3 GetVector(int i)
    {        
        return new Vector3(path.ElementAt(i).y * 2, 0, path.ElementAt(i).x * 2);
    }
    public Vector3 GetLastVector()
    {

        return new Vector3(end.y *2,0, end.x *2);
    }



}
