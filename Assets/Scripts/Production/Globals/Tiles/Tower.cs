using System.Collections;
using System.Collections.Generic;
using MemoryTool;
using UnityEngine;

public class Tower : Tile
{
    public ObjectPool projectilePool;
    GameObject towerTop;  
    Unit target;
    public float attackSpeed;


    void Fire()
    {
        projectilePool.GetUnit(true);
    }
}
