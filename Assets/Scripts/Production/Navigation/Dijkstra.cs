using System;
using UnityEngine;
using Tools;
using System.Collections.Generic;

namespace AI
{
	//TODO: Implement IPathFinder using Dijsktra algorithm.
	public class Dijkstra : IPathFinder
	{

        List<Vector2Int> accessiblesTiles;
      //  Node currentNode;
        public Dijkstra(List<Vector2Int> accessibles)
        {
            accessiblesTiles = accessibles;
        }
        public IEnumerable<Vector2Int> FindPath(Vector2Int start, Vector2Int goal)
		{
            
            Vector2Int currentNode = start;
            Dictionary<Vector2Int, Vector2Int> ancestors = new Dictionary<Vector2Int, Vector2Int>();
            Queue<Vector2Int>  neighbours = new Queue<Vector2Int>();
            neighbours.Enqueue(currentNode);

            while (neighbours.Count != 0)
            {
                currentNode = neighbours.Dequeue();
                if (currentNode == goal)
                {
                    break;
                }
                for (int i = 0; i < DirectionTools.Dirs.Length; i++)
                {
                    Vector2Int tempNode = currentNode + DirectionTools.Dirs[i];

                    if (accessiblesTiles.Contains(tempNode) && !ancestors.ContainsKey(tempNode))
                    {
                        
                        neighbours.Enqueue(tempNode);
                        ancestors.Add (tempNode, currentNode);
                    }
                }
            }

            if (ancestors.ContainsKey(goal))
            {
                List<Vector2Int> path = new List<Vector2Int>();
                foreach (var node in ancestors)
                {
                    path.Add(node.Value);
                    currentNode = ancestors[currentNode];
                }
                path.Add(currentNode);
                path.Reverse();
                return path;
            }
            return null;
        }

        //void ScanNeighbours( Vector2Int nodeToCheck)
        //{
                 
        //    for (int i = 0; i < DirectionTools.Dirs.Length; i++)
        //    {              
        //        Vector2Int tempNode = nodeToCheck += DirectionTools.Dirs[i];
        //        if (accessiblesTiles.Contains(tempNode) && !ancestors.ContainsKey(tempNode))
        //        {
        //            neighbours.Enqueue(tempNode);
        //            ancestors.Add(tempNode, nodeToCheck);
        //        }            
        //    }            
        //}
        
	}

   
}
