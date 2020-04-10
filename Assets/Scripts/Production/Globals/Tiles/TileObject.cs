using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using MemoryTool;
using UnityEngine;
[CreateAssetMenu(menuName = "Objects/Tiles/TileObject")]
public class TileObject : ScriptableObject
{
    

    [SerializeField] private TileType sign;
    [SerializeField] private GameObject prefab;
    [SerializeField] private TowerObject towerInfo;
    


    public TileType Sign { get => sign; }
    public GameObject Prefab { get => prefab; }
    public TowerObject TowerInfo { get => towerInfo; }

  
  




[Header("Pool Settings")]
    [SerializeField] public uint objectstoadd = 1;
    public uint Objectstoadd { get => objectstoadd; }
    public ObjectPool pool;

    public void InitiatePool(Transform parent = null)
    {
        pool = new ObjectPool(prefab, parent, objectstoadd);
    }

}
